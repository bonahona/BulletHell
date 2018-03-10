using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : EntityBase
{
    [Header("Movement")]
    public float MovementSpeed = 1;
    public float LerpFactor = 0.1f;
    public float ZeroMoveTreshold = 0.5f;

    [Header("Weapons")]
    public Weapon PrimaryWeapon;
    public Weapon SecondaryWeapon;

    public Transform WeaponPoint;

    public float DamageTakenIgnoreTime = 1;
    public float RespawnIgnoreTime = 2;

    private Vector3 CurrentSpeed;
    private Collider Collider;
    private Rigidbody Rigidbody;

    private bool IsInvincible;
    private float CurrentIgnoreTimer;

    private Dictionary<Weapon, WeaponInstance> WeaponInstances;

	void Start ()
    {
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();

        WeaponInstances = new Dictionary<Weapon, WeaponInstance>();
        AddWeapon(PrimaryWeapon);
        AddWeapon(SecondaryWeapon);

        Spawn();
        
	}
	
	void Update ()
    {
        if(CurrentIgnoreTimer >= 0) {
            CurrentIgnoreTimer -= Time.deltaTime;
        } else {
            IsInvincible = false;
        }
    }

    public void TakeInput(InputState inputState)
    {
        CurrentSpeed = Vector3.Lerp(CurrentSpeed, inputState.LeftStick.Transform(v => new Vector3(v.x, 0, v.y)) * MovementSpeed, LerpFactor);

        if (CurrentSpeed.sqrMagnitude < ZeroMoveTreshold) {
            CurrentSpeed = Vector3.zero;
        }

        var position = transform.position + CurrentSpeed * Time.deltaTime;
        Rigidbody.MovePosition(position);

        foreach (var instance in WeaponInstances.Values) {
            instance.Update();
        }

        if (inputState.LeftTrigger) {
            FireWeapon(SecondaryWeapon);
        }

        if (inputState.RightTrigger) {
            FireWeapon(PrimaryWeapon);
        }
    }

    public void Spawn()
    {
        IsInvincible = true;
    }

    public override void TakeDamage(float damage)
    {
        if (IsInvincible) {
            return;
        }

        Health -= damage;
        if(Health <= 0) {
            GameObject.Destroy(gameObject);
        }

        CurrentIgnoreTimer = DamageTakenIgnoreTime;
        IsInvincible = true;
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
