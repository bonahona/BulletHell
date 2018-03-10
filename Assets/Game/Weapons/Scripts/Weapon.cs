using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName ="BulletHell/New Weapon")]
public class Weapon : ScriptableObject
{
    public List<WeaponLevel> Levels;

    public void Fire(WeaponInstance instance)
    {
        var currentLevel = Mathf.Min(instance.CurrentLevel, Levels.Count);

        if(Levels[currentLevel].ProjectilePrefab == null) {
            return;
        }

        GameObject.Instantiate(Levels[currentLevel].ProjectilePrefab, instance.Player.GetWeaponPoint(), Quaternion.identity);
        instance.CurrentCooldown = Levels[currentLevel].Cooldown;
    }
}
