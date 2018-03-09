using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public float MovementSpeed = 1;
    public float LerpFactor = 0.1f;

    [Header("Input")]
    public InputDevice ControllingDevice;

    private Vector3 CurrentSpeed;
    private Collider Collider;
    private Rigidbody Rigidbody;

	void Start ()
    {
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        var inputState = ControllingDevice.Read();

        CurrentSpeed = Vector3.Lerp(CurrentSpeed, inputState.LeftStick.Transform(v => new Vector3(v.x, 0, v.y)) * MovementSpeed, LerpFactor);

        var position = transform.position + CurrentSpeed * Time.deltaTime;
        Rigidbody.MovePosition(position);

        if (inputState.LeftTrigger) {
            Debug.Log("Left");
        }

        if (inputState.RightTrigger) {
            Debug.Log("Right");
        }
    }
}
