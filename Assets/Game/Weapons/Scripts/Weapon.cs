using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName ="BulletHell/New Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject ProjectilePrefab;

    public float Cooldown;

    public void Fire(Player player)
    {
        if(ProjectilePrefab == null) {
            return;
        }

        GameObject.Instantiate(ProjectilePrefab, player.GetWeaponPoint(), Quaternion.identity);
    }
}
