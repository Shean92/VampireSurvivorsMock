using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject Enemy1;
    public float timeBetweenSpawn;
    public float lastTimeSpawned;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTimeSpawned)
        {
            lastTimeSpawned = Time.time + timeBetweenSpawn;
            Instantiate(Enemy1, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
