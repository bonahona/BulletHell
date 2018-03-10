using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy: EntityBase
{
    public AnimationClip AnimationClip;

    private Animator Animator;

    private AnimatorOverrideController AnimatorOverride;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        AnimatorOverride = new AnimatorOverrideController(Animator.runtimeAnimatorController);
        Animator.runtimeAnimatorController = AnimatorOverride;

        AnimatorOverride["CowAnimation"] = AnimationClip;
    }
}
