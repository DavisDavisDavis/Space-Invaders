using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    public GameObject BulletObject;
    Bullet Bullet;
    // Start is called before the first frame update
    void Start()
    {
        Bullet = (Bullet)BulletObject.GetComponent<Bullet>();
        InvokeRepeating("RandomShoot", 7, 3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomShoot()
    {
        Debug.Log("Bang");
        List<Enemy> frontRow = GetFrontRow();
        int rnd = Random.Range(0, frontRow.Count);
        Vector3 shootingPoint = frontRow[rnd].transform.position;
        shootingPoint.z = shootingPoint.z - 2;

        Bullet.Speed = -5;
        Bullet.Enemy = true;
        Instantiate(BulletObject, shootingPoint, BulletObject.transform.rotation);

    }

    List<Enemy> GetFrontRow()
    {
        GameObject[] Enemies;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        int highestRowEnemy = 0;
        foreach (var enemy in Enemies)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();

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
