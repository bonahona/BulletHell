using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class HealthPickup : MonoBehaviour
{
    public int Score = 50;
    public float MaxSpeed = 2;

    public float TimeToLive = 10;

    private Rigidbody Rigidbody;
    private Vector3 Movement;

    void Start()
    {
        var rotation = Random.Range(0, 2* Mathf.PI);
        Movement = new Vector3(Mathf.Sin(rotation), 0, Mathf.Cos(rotation)) * MaxSpeed;

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

            ScoreManager.Instance.AddScore(Score);
            GameObject.Destroy(gameObject);
        }
    }
}
