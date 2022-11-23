using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 6;
    public int step = 2;
    public int rowNumber = 0;
    public int points = 200;

    Player player;
    Vector3 position;
    int direction = 1;
    int xBound = 18;
    int loosingLine = 4;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        if (position.x > xBound)
        {
            position.x = xBound;
            direction = -1;

            EnemiesSwitchDirection(direction);
        }
        if (position.x < -xBound)
        {
            position.x = -xBound;
            direction = 1;

            EnemiesSwitchDirection(direction);
        }

        if (position.z < loosingLine)
        {
            player.AddReward(-1);
            Debug.Log("You lost! " + player.GetCumulativeReward());
            player.EndEpisode();
        }


        position.x += Time.deltaTime * speed * direction;
        transform.position = position;
    }

    void EnemiesSwitchDirection(int direction)
    {
        GameObject[] allEnemiesOuter = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in allEnemiesOuter)
        {
            Vector3 forwardStep = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 0.3f);
            obj.transform.position = forwardStep;

            Enemy enemyInner = obj.GetComponent<Enemy>();
            enemyInner.direction = direction;
        }
    }
}
