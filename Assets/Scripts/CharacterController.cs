using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    [FormerlySerializedAs("rigidbody")] [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected float force = 700f;
    [SerializeField] protected Animator animator;

    protected bool IsLeftPlayer;

    private void Update() => Movement();

    public void Init(bool isLeftPlayer, AnimatorController animatorController)
    {
        IsLeftPlayer = isLeftPlayer;
        animator.runtimeAnimatorController = animatorController;
        if (!isLeftPlayer)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    protected virtual void Movement()
    {
        animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ball"))
            animator.SetTrigger("Kick");
    }
}