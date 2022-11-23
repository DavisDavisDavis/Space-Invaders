using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
