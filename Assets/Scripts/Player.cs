using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEditor.PackageManager.Requests;

public class Player : Agent
{
    public int Speed;
    public GameObject BulletObject;
    Bullet Bullet;
    public int Hp = 3;

    Vector3 Position;
    float Timer = 0;
    SpawnManager spawnManager;

    // Start is called before the first frame update
    public override void Initialize()
    {
        Bullet = BulletObject.GetComponent<Bullet>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    public override void OnEpisodeBegin()
    {
        Reset();
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Move(actions.DiscreteActions);
        Fire(actions.DiscreteActions);
    }

    public void Move(ActionSegment<int> act)
    {
        var action = act[1];
        
        Position = transform.position;
        if (action == 1 & Position.x > -10)
            Position.x -= Time.deltaTime * Speed;

        if (action == 2 & Position.x < 10)
            Position.x += Time.deltaTime * Speed;
        transform.position = Position;
    }

    void Fire(ActionSegment<int> act)
    {
        var action = act[0];

        if (action == 1 && Timer <= 0)
        {
            Bullet.Speed = 7;
            Bullet.Enemy = false;
            Instantiate(Bullet, new Vector3(Position.x, Position.y, Position.z + 2), Bullet.transform.rotation);
            Timer = 1;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;

        if (Input.GetKey("left") & Position.x > -10)
            discreteActionsOut[1] = 1;
        if (Input.GetKey("right") & Position.x < 10)
            discreteActionsOut[1] = 2;

        if (Input.GetKey("space"))
            discreteActionsOut[0] = 1;
    }

    public void Reset()
    {
        Vector3 initialPosition = new Vector3(-2.3f, 0.3f, -5.3f);
        transform.position = initialPosition;

        spawnManager.Reset();
    }
}
