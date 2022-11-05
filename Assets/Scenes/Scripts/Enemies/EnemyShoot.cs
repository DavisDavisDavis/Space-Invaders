using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    Enemy[] Enemies;
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
        //Debug.Log("Front " + frontRow.Count);
        //Debug.Log(rnd);
        //Debug.Log(frontRow[rnd]);
    }

    List<Enemy> GetFrontRow()
    {
        Enemies = GetComponents<Enemy>();

        Debug.Log("HIIIIII");
        int highestRowEnemy = 0;
        foreach (var enemy in Enemies)
        {
            Debug.Log("OWo");
            if (highestRowEnemy <= enemy.rowNumber)
            {
                highestRowEnemy = enemy.rowNumber;
            }
        }

        List<Enemy> frontRow = new List<Enemy>();
        foreach (var enemy in Enemies)
        {
            if (highestRowEnemy == enemy.rowNumber)
            {
                frontRow.Add(enemy);
            }
        }
        Debug.Log("High " + frontRow.Count);

        //Returns which row is furtest forward.
        return frontRow;
    }
}
