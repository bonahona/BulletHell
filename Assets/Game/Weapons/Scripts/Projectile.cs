using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class Projectile : MonoBehaviour
{
    public GameObject OnHitEffect;

    public float Damage;
    public Vector3 Speed;
    public float TimeToLive = 10;

    private Rigidbody Rigidbody;

	void Start ()
    {
        Rigidbody = GetComponent<Rigidbody>();
	}
	

	void Update ()
    {
        var position = transform.position + Speed * Time.deltaTime;
        Rigidbody.MovePosition(position);

        TimeToLive -= Time.deltaTime;
        if(TimeToLive < 0) {
            GameObject.Destroy(gameObject);
        }
	}

    public void OnHit()
    {
        if(OnHitEffect != null) {
            GameObject.Instantiate(OnHitEffect, transform.position, OnHitEffect.transform.rotation);
        }
    }
}
