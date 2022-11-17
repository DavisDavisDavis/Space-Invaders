using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 position;
    public int speed = 5;
    public float topBound = 30;
    public float lowerBound = -10;

    public bool Enemy = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > topBound || transform.position.z < lowerBound)
            Destroy(gameObject);
    }
}
