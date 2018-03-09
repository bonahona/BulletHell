using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class EntityBase : MonoBehaviour
{
    [Header("Health")]
    public float Health;

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0) {
            GameObject.Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnAnyCollision(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnAnyCollision(other);
    }

    private void OnAnyCollision(Collider other)
    {
        var projectile = other.GetComponent<Projectile>();
        if (projectile != null) {
            TakeDamage(projectile.Damage);
        }

        var particleWeapon = other.GetComponent<ParticleWeapon>();
        if (particleWeapon != null) {
            Debug.Log("Damage");
            TakeDamage(particleWeapon.Damage);
        }

        GameObject.Destroy(other.gameObject);
    }
}
