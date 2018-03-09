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

    public int ExtraLives = 3;
    public float MaxHealth = 5;
    public float DamageTakenIgnoreTime = 1;
    public float RespawnIgnoreTime = 2;

    public Transform StartPosition;

    private Vector3 CurrentSpeed;
    private Collider Collider;
    private Rigidbody Rigidbody;

    private float CurrentIgnoreTimer;
    private bool IsDead;

    private Dictionary<Weapon, WeaponInstance> WeaponInstances;

	void Start ()
    {
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();

        WeaponInstances = new Dictionary<Weapon, WeaponInstance>();
        AddWeapon(PrimaryWeapon);
        AddWeapon(SecondaryWeapon);

        Respawn();
        
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

        if(CurrentIgnoreTimer >= 0) {
            CurrentIgnoreTimer -= Time.deltaTime;
        } else {
            Collider.enabled = true;
        }
    }

    public void Respawn()
    {
        transform.position = StartPosition.position;
        Health = MaxHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        CurrentIgnoreTimer = DamageTakenIgnoreTime;
        Collider.enabled = false;
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
