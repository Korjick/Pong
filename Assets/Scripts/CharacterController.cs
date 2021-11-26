﻿using System;
using Assets.Scripts;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    public event Action OnGetDamage;

    [SerializeField] protected Rigidbody2D _rigidbody;

    [SerializeField] protected float force = 700f;
    [SerializeField] protected Animator animator;

    public bool IsLeftPlayer => isLeftPlayer;
    protected bool isLeftPlayer, isMoving;
    protected ContainerForAbilities cfa;
    protected SkillContainer skillContainer;

    private void Update() => Movement();

    public virtual void Init(bool isLeftPlayer, AnimatorOverrideController animatorController,
        ContainerForAbilities cfa, SkillContainer skillContainer)
    {
        this.isLeftPlayer = isLeftPlayer;
        this.cfa = cfa;
        this.skillContainer = skillContainer;
        animator.runtimeAnimatorController = animatorController;
        if (!isLeftPlayer)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    protected virtual void Movement()
    {
        animator.SetBool("IsMoving", isMoving);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ball"))
            animator.SetTrigger("Kick");
    }

    protected virtual void UseAbility()
    {
        Debug.Log(gameObject.name + " has no ability");
    }

    public void GetDamage()
    {
        Debug.Log(gameObject.name + " damaged");
        OnGetDamage?.Invoke();
    }
}