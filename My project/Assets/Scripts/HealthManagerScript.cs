using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public bool immortal;
    public bool poisoned;
    private float poisonRate;
    private float lastTimePoisoned;
    private float poisonDamage;
    public GameObject Loot;
    public ParticleSystem poison;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (poisoned)
        {
            poison.gameObject.SetActive(true);
            TakePoisonDamage();
        }
    }

    private void TakePoisonDamage()
    {
        if (Time.time > lastTimePoisoned)
        {
            lastTimePoisoned = Time.time + poisonRate;
            TakeDamage(poisonDamage);
        }
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

    public void StartPoison(float poisonRate, float poisonDamage)
    {
        poisoned = true;
        this.poisonRate = poisonRate;
        this.poisonDamage = poisonDamage;
    }

    void Die()
    {
        Instantiate(Loot, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.SetActive(false);
    }
}
