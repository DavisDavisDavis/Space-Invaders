using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Position;
    public int Speed = 5;
    public float top_bound = 30;
    public float lower_bound = -10;

    public bool Enemy = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        if (transform.position.z > top_bound || transform.position.z < lower_bound)
            Destroy(gameObject);
    }
}
