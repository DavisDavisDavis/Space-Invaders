using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RandomShoot();

    }

    void RandomShoot()
    {

        List<Enemy> frontRow = GetFrontRow();
        int rnd = Random.Range(0, frontRow.Count);
        Vector3 shootingPoint = frontRow[1].transform.position;

        Instantiate(EnemyBullet, shootingPoint, EnemyBullet.transform.rotation);

    }

    List<Enemy> GetFrontRow()
    {
        GameObject[] Enemies;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log("HIIIIII");
        int highestRowEnemy = 0;
        foreach (var enemy in Enemies)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();
            Debug.Log("OWo");
            if (highestRowEnemy <= enemyComponent.rowNumber)
            {
                highestRowEnemy = enemyComponent.rowNumber;
            }
        }

        List<Enemy> frontRow = new List<Enemy>();
        foreach (var enemy in Enemies)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();
            if (highestRowEnemy == enemyComponent.rowNumber)
            {
                frontRow.Add(enemyComponent);
            }
        }
        Debug.Log("High " + frontRow.Count);

        //Returns which row is furtest forward.
        return frontRow;
    }
}
