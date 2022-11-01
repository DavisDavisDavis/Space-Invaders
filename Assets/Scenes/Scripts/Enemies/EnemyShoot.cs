using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    GameObject[] Enemies;
    GameObject[] FrontRowEnemies;
    // Start is called before the first frame update
    void Start()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(Enemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomShoot()
    {

    }

    void CheckFrontRow()
    {
        GameObject tmpEnemy =  Enemies[0];
        foreach (var enemy in Enemies)
        {
            if (tmpEnemy.transform.position.z > enemy.transform.position.z)
            {

            }

            if (tmpEnemy.transform.position.z == enemy.transform.position.z)
            {

            }
            tmpEnemy = enemy;
        }
    }
}
