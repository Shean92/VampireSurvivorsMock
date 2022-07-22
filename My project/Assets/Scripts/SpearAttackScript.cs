using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttackScript : MonoBehaviour
{
    public GameObject bullet;
    public float timeBetweenShots;
    public float lastTimeShot;
    private GameObject player;
    private GameObject closestEnemy;
    private GameObject[] enemies;


    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        closestEnemy = enemies[0];
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            if (!closestEnemy)
            {
                closestEnemy = enemies[0];
            }
            float distanceToTarget = Vector2.Distance(transform.position, closestEnemy.transform.position);

            foreach (GameObject enemy in enemies)
            {
                float distanceToNewTarget = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToNewTarget < distanceToTarget)
                {
                    closestEnemy = enemy;
                }
            }
        }
        else
        {
            closestEnemy = null;
        }
        if (closestEnemy && Time.time > lastTimeShot)
        {
            lastTimeShot = Time.time + timeBetweenShots;
            Shoot();
        }
    }

    public void Shoot()
    {
        var offset = -90f;
        Vector2 direction = closestEnemy.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        Instantiate(bullet, player.transform.position, rotation);
    }
}
