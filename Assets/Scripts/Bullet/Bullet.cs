using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 position;
    public int speed = 5;
    public bool enemy = false;

    float topBound = 30;
    float lowerBound = -10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > topBound || transform.position.z < lowerBound)
            Destroy(gameObject);
    }
}
