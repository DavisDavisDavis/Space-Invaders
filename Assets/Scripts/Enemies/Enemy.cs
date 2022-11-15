using System.Collections;
using System.Collections.Generic;
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
            Position.z -= Step;
            Direction = -1;
        }

        if (Position.x < -xBound)
        {
            Position.x = -xBound;
            Position.z -= Step;
            Direction = 1;
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
}
