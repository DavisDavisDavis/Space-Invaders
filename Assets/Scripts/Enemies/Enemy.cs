using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 Position;
    int Direction = 1;
    int xBound = 18;
    int LoosingLine = 4;

    public int rowNumber = 0;
    public int Points = 200;
    public int Speed;
    public int Step;

    Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;

        if (Position.x > xBound)
        {
            Position.x = xBound;
            Direction = -1;

            EnemiesSwitchDirection(Direction);
        }

        if (Position.x < -xBound)
        {
            Position.x = -xBound;
            Direction = 1;

            EnemiesSwitchDirection(Direction);
        }

        if (Position.z < LoosingLine)
        {
            Debug.Log("You lost");

            Player.AddReward(-1);
            Player.EndEpisode();
        }


        Position.x += Time.deltaTime * Speed * Direction;
        transform.position = Position;
    }

    void EnemiesSwitchDirection(int direction)
    {
        GameObject[] allEnemiesOuter = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in allEnemiesOuter)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 0.3f);

            Enemy enemyInner = obj.GetComponent<Enemy>();
            enemyInner.Direction = direction;
        }

        Debug.Log("Wha");
    }
}
