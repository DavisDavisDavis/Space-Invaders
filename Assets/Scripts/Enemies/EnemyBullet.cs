using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int speed;

    Vector3 position;
    int lower_bound = -30;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z < lower_bound)
            Destroy(gameObject);
    }
}
