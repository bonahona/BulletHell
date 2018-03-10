using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy: EntityBase
{
    public GameObject OnDeathEffect;

    public float SelfDesctructTimer = 10;

    public List<EnemyDrops> LootTable;

    private Animator Animator;

    private AnimatorOverrideController AnimatorOverride;

    public override void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0) {
            GameObject.Destroy(transform.parent.gameObject);
            TryLoot();
            SpawnEffect(OnDeathEffect);
        }
    }

    private void Start()
    {
        GameObject.Destroy(gameObject.transform.parent.gameObject, SelfDesctructTimer);
        
        if(AnimatorOverride == null) {
            CreateAnimationOverride();
        }

        
    }
    
    private void CreateAnimationOverride()
    {
        Animator = GetComponent<Animator>();
        AnimatorOverride = new AnimatorOverrideController(Animator.runtimeAnimatorController);
        Animator.runtimeAnimatorController = AnimatorOverride;
    }

    public void SetAnimationClip(AnimationClip clip)
    {
        if (AnimatorOverride == null) {
            CreateAnimationOverride();
        }
        AnimatorOverride["CowAnimation"] = clip;
    }

    private void TryLoot()
    {
        foreach(var lootEntry in LootTable) {
            var roll = Random.Range(0, 1);
            if(roll > lootEntry.DropChance) {
                if(lootEntry.Drop != null) {
                    GameObject.Instantiate(lootEntry.Drop, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
