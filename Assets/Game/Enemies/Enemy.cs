using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy: EntityBase
{
    public int DeathScore = 10;

    public GameObject OnDeathEffect;

    public float SelfDesctructTimer = 10;

    public List<EnemyDrops> LootTable;

    private Animator Animator;

    private AnimatorOverrideController AnimatorOverride;
    private float CurrentTimer = 0;

    private void Start()
    {
        if (AnimatorOverride == null) {
            CreateAnimationOverride();
        }
    }

    private void Update()
    {
        CurrentTimer += Time.deltaTime;
        if(CurrentTimer >= SelfDesctructTimer) {
            Die(false);
        }
    }

    public override void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0) {
            Die(true);
        }
    }

    private void Die(bool isPlayerKilled)
    {
        foreach(var projectile in GetComponentsInChildren<ParticleSystem>()) {
            projectile.transform.parent = null;
            projectile.loop = false;
        }

        GameObject.Destroy(transform.parent.gameObject);

        if (isPlayerKilled) {
            ScoreManager.Instance.AddScore(DeathScore);
            TryLoot();
        }

        SpawnEffect(OnDeathEffect);
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
            var roll = Random.Range(0.0f, 1.0f); 
            if(roll < lootEntry.DropChance) {
                if(lootEntry.Drop != null) {
                    GameObject.Instantiate(lootEntry.Drop, transform.position, lootEntry.Drop.transform.rotation);
                }
            }
        }
    }
}
