using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy: EntityBase
{
    public float SelfDesctructTimer = 10;
    public AnimationClip AnimationClip;

    private Animator Animator;

    private AnimatorOverrideController AnimatorOverride;

    public override void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0) {
            GameObject.Destroy(transform.parent.gameObject);
        }
    }

    private void Start()
    {
        GameObject.Destroy(gameObject.transform.parent.gameObject, SelfDesctructTimer);
        
        if(AnimatorOverride == null) {
            CreateAnimationOverride();
        }

        AnimatorOverride["CowAnimation"] = AnimationClip;
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
}
