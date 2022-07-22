using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovementScript : MonoBehaviour
{
    public float speed;
    public float damage;
    public float timeBetweenAttacks;
    public float lastTimeAttacked;
    public Rigidbody2D rb;
    private GameObject player;
    public LayerMask friendlies;
    public ParticleSystem bloodSplatter;

    // Wander Script General to all Ai
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && Time.time > lastTimeAttacked)
        {
            lastTimeAttacked = Time.time + timeBetweenAttacks;
            other.gameObject.GetComponent<HealthManagerScript>().TakeDamage(damage);
            bloodSplatter.Stop();
            bloodSplatter.Emit(100);
        }
    }
}
