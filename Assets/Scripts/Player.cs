using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class Player : Agent
{
    public int speed = 20;
    public int hp = 3;
    public GameObject bulletOuter;

    Vector3 position;
    float timer = 0;
    Bullet bulletInner;
    SpawnManager spawnManager;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    public override void Initialize()
    {
        bulletInner = bulletOuter.GetComponent<Bullet>();
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreManager>(); 
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
        position = transform.position;

        if (action == 1 & position.x > -12)
            position.x -= Time.deltaTime * speed;
        if (action == 2 & position.x < 12)
            position.x += Time.deltaTime * speed;

        transform.position = position;
    }

    void Fire(ActionSegment<int> act)
    {
        var action = act[0];

        AddReward(-0.003f);

        if (action == 1 && timer <= 0)
        {
            bulletInner.speed = 10;
            bulletInner.enemy = false;

            Instantiate(bulletOuter, new Vector3(position.x, position.y, position.z + 2), bulletOuter.transform.rotation);
            timer = 0.7f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;

        if (Input.GetKey("left") & position.x > -12)
            discreteActionsOut[1] = 1;
        if (Input.GetKey("right") & position.x < 12)
            discreteActionsOut[1] = 2;

        if (Input.GetKey("space"))
            discreteActionsOut[0] = 1;
    }

    public void Reset()
    {
        Vector3 initialPosition = new Vector3(-2.3f, 0.3f, -5.3f);
        transform.position = initialPosition;

        scoreManager.Total = 0;

        spawnManager.ResetEnemies();
        spawnManager.ResetCovers();
        spawnManager.ResetUfo();

        GameObject[] allBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var bullet in allBullets)
            Destroy(bullet);
    }
}
