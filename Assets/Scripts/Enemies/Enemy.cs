using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 Position;
    int Direction = 1;
    int xBound = 18;

    public int rowNumber = 0;
    public int Points = 200;
    public int Speed;
    public int Step;
    // Start is called before the first frame update
    void Start()
    {
        
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

        Position.x += Time.deltaTime * Speed * Direction;
        transform.position = Position;
    }
}
