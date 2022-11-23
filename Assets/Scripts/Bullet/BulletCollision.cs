using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    ScoreManager scoreText;
    Bullet bullet;
    Player player;
    SpawnManager spawnManager;
    int totalEnemies;
    // Start is called before the first frame update
    void Start()
    {
        bullet = gameObject.GetComponent<Bullet>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!bullet.enemy)
        {
            PlayerShotBullet(other);
        }
        if (bullet.enemy)
        {
            EnemyShotBullet(other);
        }

        if (other.GetComponent<CoverBehaviour>())
        {
            CoverBehaviour cover = other.GetComponent<CoverBehaviour>();
            cover.hp -= 1;
        }

        Destroy(gameObject);
    }

    void PlayerShotBullet(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.GetComponent<Enemy>();
            scoreText.UpdateHighScore(enemy.points);
            
            player.AddReward(0.1f);
            Destroy(other.gameObject);

            spawnManager.totalNumberOfEnemies = spawnManager.totalNumberOfEnemies - 1;

            Debug.Log(spawnManager.totalNumberOfEnemies);
            if (0 >= spawnManager.totalNumberOfEnemies)
            {
                player.AddReward(1);
                player.EndEpisode();

                Debug.Log("Won!!!");
            }

        }
        if (other.GetComponent<Ufo>())
        {
            Ufo ufo = other.GetComponent<Ufo>();
            scoreText.UpdateHighScore(ufo.Points);

            player.AddReward(0.08f);
            Destroy(other.gameObject);
        }
    }

    void EnemyShotBullet(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            player.AddReward(-1.2f);
            Debug.Log("OUCH! " + player.GetCumulativeReward());
            player.EndEpisode();
        }
    }
}
