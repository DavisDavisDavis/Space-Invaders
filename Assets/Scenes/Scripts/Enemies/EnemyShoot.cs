using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    Enemy[] Enemies;
    GameObject[] FrontRowEnemies;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = GetComponentsInChildren<Enemy>();
        Debug.Log(Enemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomShoot()
    {



    }

    List<Enemy> GetFrontRow()
    {
        Enemy highestRowEnemy =  Enemies[0];
        foreach (var enemy in Enemies)
        {
            if (highestRowEnemy.transform.position.z < enemy.transform.position.z)
            {
                highestRowEnemy = enemy;
            }
        }

        List<Enemy> frontRow =  new List<Enemy>();
        foreach (var enemy in Enemies)
        {
            if (highestRowEnemy.rowNumber == enemy.rowNumber)
            {
                frontRow.Add(enemy);
            }
        }

        //Returns which row is furtest forward.
        return frontRow;
    }
}
