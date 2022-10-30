using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int xBound = 15;
    public int Direction = 1;

    public GameObject Ufo;
    public int Points = 800;
    public int Speed;

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnRandomUfo", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRandomUfo()
    {
        Debug.Log("UFOOO");
        if (0 == Random.Range(0, 2))
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
        int randomPoint = Direction * xBound;

        Vector3 spawnPoint = new Vector3(randomPoint, 1.5f, 24);
        Instantiate(Ufo, spawnPoint, Ufo.transform.rotation);
    }
}
