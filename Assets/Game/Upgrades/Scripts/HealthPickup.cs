using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class HealthPickup : MonoBehaviour
{
    public Vector3 Movement;
    public float TimeToLive = 10;

    private Rigidbody Rigidbody;

    void Start()
    {
        GameObject.Destroy(gameObject, TimeToLive);
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var position = transform.position + Movement * Time.deltaTime;
        Rigidbody.MovePosition(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerShip = other.GetComponent<PlayerShip>();
        if (playerShip != null) {
            playerShip.Health = Mathf.Min(playerShip.Health + 1, playerShip.MaxHealth);

            GameObject.Destroy(gameObject);
        }
    }
}
