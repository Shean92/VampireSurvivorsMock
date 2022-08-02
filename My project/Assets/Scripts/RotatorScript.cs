using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public float rotationSpeed;
    private GameObject player;
    public Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Follow player
        rb.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (player.GetComponent<PlayerController>().moveSpeed + 5) * Time.deltaTime);
        //rotate at speed
        gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime * 100);
    }
}
