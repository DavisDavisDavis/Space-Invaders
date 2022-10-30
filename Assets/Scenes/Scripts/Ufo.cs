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
        if (Position.x > xBound || Position.x < -xBound)
        {
            Destroy(gameObject);
        }
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
}