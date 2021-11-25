using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    [FormerlySerializedAs("rigidbody")] [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected float force = 700f;
    [SerializeField] protected Animator animator;

    protected bool isLeftPlayer;
    protected bool isMoving;

    private void Update() => Movement();

    public void Init(bool isLeftPlayer, AnimatorOverrideController animatorController)
    {
        this.isLeftPlayer = isLeftPlayer;
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
}