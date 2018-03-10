using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponInstance
{
    public PlayerShip Player;
    public Weapon Weapon;

    public int CurrentLevel;
    public float CurrentCooldown;

    public void Fire(PlayerShip player)
    {
        if (CurrentCooldown < 0) {
            Weapon.Fire(this);
        }
    }

    public void Update()
    {
        if (CurrentCooldown >= 0) {
            CurrentCooldown -= Time.deltaTime;
        }
    }

    public void Upgrade()
    {
        CurrentLevel++;
    }
}
