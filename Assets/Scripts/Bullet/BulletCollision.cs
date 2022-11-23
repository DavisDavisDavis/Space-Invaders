using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BulletCollision : MonoBehaviour
{
    ScoreManager ScoreText;
    Bullet Bullet;
    Player Player;
    SpawnManager spawnManager;
    int totalEnemies;
    // Start is called before the first frame update
    void Start()
    {
        Bullet = gameObject.GetComponent<Bullet>();
            
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreManager>();

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Bullet.Enemy)
        {
            PlayerBullet(other);
        }

        if (Bullet.Enemy)
        {
            EnemyBullet(other);
        }

        if (other.GetComponent<CoverBehaviour>())
        {
            CoverBehaviour cover = (CoverBehaviour)other.GetComponent<CoverBehaviour>();
            cover.hp -= 1;
        }

        Destroy(gameObject);
    }

    void PlayerBullet(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = (Enemy)other.GetComponent<Enemy>();
            ScoreText.UpdateHighScore(enemy.points);
            
            Player.AddReward(0.1f);
            Destroy(other.gameObject);

            spawnManager.totalNumberOfEnemies = spawnManager.totalNumberOfEnemies - 1;

            Debug.Log(spawnManager.totalNumberOfEnemies);
            if (0 >= spawnManager.totalNumberOfEnemies)
            {
                Player.AddReward(1);
                Player.EndEpisode();

                Debug.Log("Won!!!");
            }

        }
        if (other.GetComponent<Ufo>())
        {
            Ufo ufo = (Ufo)other.GetComponent<Ufo>();
            ScoreText.UpdateHighScore(ufo.Points);

            Player.AddReward(0.08f);
            Destroy(other.gameObject);
        }
    }

    void EnemyBullet(Collider other)
    {
        if (other.GetComponent<Player>())
        {

            Player.AddReward(-1.2f);
            Debug.Log("OUCH! " + Player.GetCumulativeReward());
            Player.EndEpisode();
        }
    }
}
