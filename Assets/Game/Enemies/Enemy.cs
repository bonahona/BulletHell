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
        Animator = GetComponent<Animator>();
        AnimatorOverride = new AnimatorOverrideController(Animator.runtimeAnimatorController);
        Animator.runtimeAnimatorController = AnimatorOverride;

        AnimatorOverride["CowAnimation"] = AnimationClip;
    }

    public void SetAnimationClip(AnimationClip clip)
    {
        AnimatorOverride["CowAnimation"] = clip;
    }
}
