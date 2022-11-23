using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject outerBullet;
    Bullet innerBullet;
    // Start is called before the first frame update
    void Start()
    {
        innerBullet = outerBullet.GetComponent<Bullet>();
        InvokeRepeating("RandomShoot", 7, 3);
    }

    void RandomShoot()
    {
        List<Enemy> frontRow = GetFrontRow();
        int rnd = Random.Range(0, frontRow.Count);
        Vector3 shootingPoint = frontRow[rnd].transform.position;
        shootingPoint.z = shootingPoint.z - 2;

        innerBullet.speed = -5;
        innerBullet.enemy = true;
        Instantiate(outerBullet, shootingPoint, outerBullet.transform.rotation);
    }

    List<Enemy> GetFrontRow()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int highestRowEnemy = 0;
        foreach (var enemy in enemies)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();

            if (highestRowEnemy <= enemyComponent.rowNumber)
            {
                highestRowEnemy = enemyComponent.rowNumber;
            }
        }

        List<Enemy> frontRow = new List<Enemy>();
        foreach (var enemy in enemies)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();
            if (highestRowEnemy == enemyComponent.rowNumber)
            {
                frontRow.Add(enemyComponent);
            }
        }

        return frontRow;
    }
}
