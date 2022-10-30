using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    Vector3 Position;
    int xBound = 15;
    int Direction = 1;

    public int Points = 800;
    public int Speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomUfo", 1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;
        Position.x += Direction * Speed * Time.deltaTime;

        if (Position.x > xBound || Position.x < -xBound)
        {
            Destroy(gameObject);
        }

        transform.position = Position;
    }

    void SpawnRandomUfo()
    {
        Debug.Log("UFOOO");
        if (0 == Random.Range(0, 2))
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
        int randomPoint = Direction * xBound;

        Vector3 spawnPoint = new Vector3(randomPoint, 1.5f, 24);
        Instantiate(gameObject, spawnPoint, gameObject.transform.rotation);
    }
}