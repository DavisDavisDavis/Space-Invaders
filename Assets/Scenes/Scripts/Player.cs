using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed;
    Vector3 Position;
    public GameObject Bullet;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;
        if (Input.GetKey("left") & Position.x > -10)
            Position.x -= Time.deltaTime * Speed;

        if (Input.GetKey("right") & Position.x < 10)
            Position.x += Time.deltaTime * Speed;
        transform.position = Position;

        Fire();
    }

    void Fire()
    {
        if (Input.GetKey("space") && Timer <= 0)
        {
            Instantiate(Bullet, new Vector3(Position.x, Position.y, Position.z + 2), Bullet.transform.rotation);
            Timer = 1;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
}
