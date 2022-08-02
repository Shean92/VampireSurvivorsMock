using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float gems;
    public int level = 1;
    private HealthManagerScript playerHealth;
    private ParticleSystem levelUp;
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthManagerScript>();
        levelUp = player.transform.Find("Level Up").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (gems >= Mathf.Pow(level, 2))
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        levelUp.Emit(100);
        level++;
        playerHealth.maxHealth++;
    }

    public void GainGems(float amount)
    {
        gems += amount;
    }
}
