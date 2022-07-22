using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float collectDistance;
    public float strength;
    public float attackRate;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public HealthManagerScript playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<HealthManagerScript>();
    }
    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}