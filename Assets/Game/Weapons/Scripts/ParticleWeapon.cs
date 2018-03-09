using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeapon : MonoBehaviour
{
    public float Damage;

    void OnParticleCollision(GameObject other)
    {
        var entity = other.GetComponent<EntityBase>();
        if(entity != null) {
            entity.TakeDamage(Damage);
        }
    }
}
