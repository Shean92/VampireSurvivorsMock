using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public bool immortal;
    public GameObject Loot;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !immortal)
        {
            immortal = true;
            Die();
        }

    }

    void Die()
    {
        Instantiate(Loot, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.SetActive(false);
    }
}
