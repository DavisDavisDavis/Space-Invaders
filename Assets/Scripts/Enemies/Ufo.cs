using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour
{
    public int points = 800;

    Vector3 position;
    int speed = 4;
    int direction = 1;
    int xBound = 20;
    int xSpawnBound = 18;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x < -xSpawnBound + 1)
        {
            direction = 1;
        }
        if (transform.position.x > xSpawnBound - 1)
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        position.x += direction * speed * Time.deltaTime;

        if (position.x > xBound || position.x < -xBound)
        {
            Destroy(gameObject);
        }

        transform.position = position;
    }
}