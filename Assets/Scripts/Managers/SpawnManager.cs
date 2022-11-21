using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int xBound = 18;

    int xStep = 3;
    int yStep = -2;
    public int Direction = 1;

    public GameObject Ufo;
    public GameObject Enemy;
    public GameObject Covers;
    public int Points = 800;
    public int Speed;
    public int numberOfEnemiesX = 8;
    public int numberOfEnemiesY = 5;
    public int totalNumberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomUfo", 17, 12);
   
        totalNumberOfEnemies = numberOfEnemiesX * numberOfEnemiesY;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemies(int xNumberOfEnemies, int yNumberOfEnemies, Vector3 initalSpawnPosition)
    {
        
        Vector3 nextSpawnPosition = initalSpawnPosition;

        Enemy thisEnemy;
        thisEnemy = Enemy.GetComponent<Enemy>();

        for (int y = 0; y < yNumberOfEnemies; y++)
        {
            for (int x = 0; x < xNumberOfEnemies; x++)
            {
                thisEnemy.rowNumber = y;
                Instantiate(thisEnemy, nextSpawnPosition, Enemy.transform.rotation);
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
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
        int randomPoint = Direction * xBound;

        Vector3 spawnPoint = new Vector3(randomPoint, 1.5f, 24);
        Instantiate(Ufo, spawnPoint, Ufo.transform.rotation);
    }

    public void ResetEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in allEnemies)
        {
            Destroy(enemy);
        }

        SpawnEnemies(8, 5, new Vector3(-7, 0, 20));
    }

    public void ResetCovers()
    {
        GameObject[] allCover = GameObject.FindGameObjectsWithTag("Cover");

        foreach (var cover in allCover)
        {
            Destroy(cover);
        }

        Vector3 coversPosition = new Vector3(13, 0.5f, -0.5f);
        Instantiate(Covers, coversPosition, Covers.transform.rotation);
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
