using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Position;
    public int Speed;
    public float lower_bound = -30;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        if (transform.position.z > lower_bound)
            Destroy(gameObject);
    }
}
