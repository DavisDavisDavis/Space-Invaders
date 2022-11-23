using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ufo;
    public GameObject enemy;
    public GameObject covers;
    public int points = 800;
    public int speed;
    public int totalNumberOfEnemies;
    public int direction = 1;

    int xBound = 18;
    int xStep = 3;
    int yStep = -2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomUfo", 17, 12);
    }

    void SpawnEnemies(int xNumberOfEnemies, int yNumberOfEnemies, Vector3 initalSpawnPosition)
    {
        totalNumberOfEnemies = xNumberOfEnemies * yNumberOfEnemies;

        Vector3 nextSpawnPosition = initalSpawnPosition;

        Enemy thisEnemy;
        thisEnemy = enemy.GetComponent<Enemy>();

        for (int y = 0; y < yNumberOfEnemies; y++)
        {
            for (int x = 0; x < xNumberOfEnemies; x++)
            {
                thisEnemy.rowNumber = y;
                Instantiate(thisEnemy, nextSpawnPosition, enemy.transform.rotation);
                nextSpawnPosition.x += xStep;
            }

            nextSpawnPosition.z += yStep;
            nextSpawnPosition.x = initalSpawnPosition.x;
        }
    }

    void SpawnRandomUfo()
    {
        if (0 == Random.Range(0, 2))
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        int randomPoint = direction * xBound;

        Vector3 spawnPoint = new Vector3(randomPoint, 1.5f, 24);
        Instantiate(ufo, spawnPoint, ufo.transform.rotation);
    }

    public void ResetEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in allEnemies)
        {
            Destroy(enemy);
        }

        SpawnEnemies(8, 5, new Vector3(-7, 0, 23));
    }

    public void ResetCovers()
    {
        GameObject[] allCover = GameObject.FindGameObjectsWithTag("Cover");

        foreach (var cover in allCover)
        {
            Destroy(cover);
        }

        Vector3 coversPosition = new Vector3(13, 0.5f, -0.5f);
        Instantiate(covers, coversPosition, covers.transform.rotation);
    }

    public void ResetUfo()
    {
        GameObject[] allUfo = GameObject.FindGameObjectsWithTag("Ufo");

        foreach (var ufo in allUfo)
        {
            Destroy(ufo);
        }
    }
}
