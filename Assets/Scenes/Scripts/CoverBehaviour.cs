using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverBehaviour : MonoBehaviour
{
    public int hp = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 3:
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                break;
            case 2:
                gameObject.GetComponent<Renderer>().material.color = new Color(100, 0, 0);
                break;
            case 1:
                gameObject.GetComponent<Renderer>().material.color = new Color(0, 100, 0);
                break;
            case 0:
                Destroy(gameObject);
                break;
            default:
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 110, 146);
                break;
        }
    }
}
