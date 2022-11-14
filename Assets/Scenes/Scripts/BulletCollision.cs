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
    Agent Agent;
    // Start is called before the first frame update
    void Start()
    {
        Bullet = gameObject.GetComponent<Bullet>();
            
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreManager>();

        Agent = GetComponent<Agent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Bullet.Enemy)
        {
            Debug.Log("Player shoot");
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
            ScoreText.UpdateHighScore(enemy.Points);
            
            Agent.AddReward(0.01f);
            Destroy(other.gameObject);
        }
        if (other.GetComponent<Ufo>())
        {
            Ufo ufo = (Ufo)other.GetComponent<Ufo>();
            ScoreText.UpdateHighScore(ufo.Points);

            Destroy(other.gameObject);
        }

        
    }

    void EnemyBullet(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player player = (Player)other.GetComponent<Player>();
            player.Hp -= 1;

            Agent.AddReward(-1);
            //Agent.EndEpisode();

            Debug.Log("OUCH!");
        }
    }
}
