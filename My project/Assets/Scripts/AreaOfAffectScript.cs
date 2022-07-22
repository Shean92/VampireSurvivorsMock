using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfAffectScript : MonoBehaviour
{
    public bool poisonous;
    public float damageRate;
    public float damageMultiplyer;
    private float lastTimeDamaged;
    public float destroyTime;
    public float radius = 5f;
    public LayerMask targetLayer;
    public LayerMask friendlies;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        foreach (Collider2D enemy in enemies)
        {
            Debug.Log(enemy);
            if (poisonous)
            {
                Debug.Log("poison");
                enemy.GetComponent<HealthManagerScript>().StartPoison(damageRate, damageMultiplyer);
            }
            else if (Time.time > lastTimeDamaged)
            {
                Debug.Log("damage");
                lastTimeDamaged = Time.time + damageRate;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
    }
}
