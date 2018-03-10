using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponInstance
{
    public PlayerShip Player;
    public Weapon Weapon;

    public float CurrentCooldown;

    public void Fire(PlayerShip player)
    {
        if (CurrentCooldown < 0) {
            Weapon.Fire(player);
            CurrentCooldown = Weapon.Cooldown;
        }
    }

    public void Update()
    {
        if (CurrentCooldown >= 0) {
            CurrentCooldown -= Time.deltaTime;
        }
    }
}
