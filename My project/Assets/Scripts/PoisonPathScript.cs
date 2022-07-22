using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPathScript : MonoBehaviour
{
    public float timeBetweenShots;
    public float lastTimeShot;
    private GameObject player;
    public GameObject poison;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTimeShot * player.GetComponent<PlayerController>().attackRate)
        {
            lastTimeShot = Time.time + timeBetweenShots;
            Instantiate(poison, player.transform.position, player.transform.rotation);
        }
    }
}
