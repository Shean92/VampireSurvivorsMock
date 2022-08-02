using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWeaponScript : MonoBehaviour
{
    public float damageMultiplyer;
    private float lastTimeDamaged;
    public float timeBetweenAttacks;
    public ParticleSystem bloodSplatter;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies") && Time.time > lastTimeDamaged)
        {
            lastTimeDamaged = Time.time + timeBetweenAttacks;
            other.gameObject.GetComponent<HealthManagerScript>().TakeDamage(damageMultiplyer);
            bloodSplatter.Stop();
            bloodSplatter.Emit(100);
        }
    }
}
