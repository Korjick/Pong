using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class RyuController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private float force = 100f;
        [SerializeField] private float friction = .1f;
        [SerializeField] private Animator animator;

        private KeyCode _up, _down, _specialPower;

        private void Start() => SetKeycodes();

        private void Update() => Movement();

        private void SetKeycodes()
        {
            _up = KeyCode.W;
            _down = KeyCode.S;
            _specialPower = KeyCode.X;
        }

        private void Movement()
        {
            animator.SetFloat("Speed", rigidbody.velocity.magnitude);

            Vector2 move = Vector2.zero;
            if (Input.GetKey(_up))
                move += Vector2.up;
            if (Input.GetKey(_down))
                move += Vector2.down;
            if (move.magnitude > 0.001f)
            {
                rigidbody.velocity = move * force;
            }

            if (rigidbody.velocity.y > friction)
                rigidbody.velocity -= new Vector2(0, friction);
            else if (rigidbody.velocity.y < -friction)
                rigidbody.velocity += new Vector2(0, friction);
            else rigidbody.velocity = Vector2.zero;

            if (Input.GetKey(_specialPower))
            {
                Debug.Log("Ryu use Ability");
                animator.SetTrigger("Ability");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag.Equals("Ball"))
                animator.SetTrigger("Kick");
        }
    }
}