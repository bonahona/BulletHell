using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : EntityBase
{
    [Header("Movement")]
    public float MovementSpeed = 1;
    public float LerpFactor = 0.1f;
    public float ZeroMoveTreshold = 0.5f;

    [Header("Weapons")]
    public Weapon PrimaryWeapon;
    public Weapon SecondaryWeapon;

    public Transform WeaponPoint;

    [Header("Input")]
    public InputDevice ControllingDevice;

    private Vector3 CurrentSpeed;
    private Collider Collider;
    private Rigidbody Rigidbody;

    private Dictionary<Weapon, WeaponInstance> WeaponInstances;

	void Start ()
    {
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();

        WeaponInstances = new Dictionary<Weapon, WeaponInstance>();
        AddWeapon(PrimaryWeapon);
        AddWeapon(SecondaryWeapon);
        
	}
	
	void Update ()
    {
        var inputState = ControllingDevice.Read();

        CurrentSpeed = Vector3.Lerp(CurrentSpeed, inputState.LeftStick.Transform(v => new Vector3(v.x, 0, v.y)) * MovementSpeed, LerpFactor);

        if(CurrentSpeed.sqrMagnitude < ZeroMoveTreshold) {
            CurrentSpeed = Vector3.zero;
        }

        var position = transform.position + CurrentSpeed * Time.deltaTime;
        Rigidbody.MovePosition(position);

        foreach(var instance in WeaponInstances.Values) {
            instance.Update();
        }

        if (inputState.LeftTrigger) {
            FireWeapon(SecondaryWeapon);
        }

        if (inputState.RightTrigger) {
            FireWeapon(PrimaryWeapon);
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        if(weapon == null) {
            return;
        }

        WeaponInstances[weapon] = new WeaponInstance { Weapon = weapon, Player = this };
    }

    public void FireWeapon(Weapon weapon)
    {
        if(weapon == null) {
            return;
        }

        WeaponInstances[weapon].Fire(this);
    }

    public Vector3 GetWeaponPoint()
    {
        return WeaponPoint.position;
    }
}
