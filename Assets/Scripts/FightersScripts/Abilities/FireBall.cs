using System;
using UnityEngine;

namespace FightersScripts
{
    public class FireBall : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        private float timerMaxTime = 5f, time;
        private bool isTargetLeft;

        public void Init(Ball ball, bool isLeftBall, bool isParentLeft)
        {
            isTargetLeft = !isParentLeft;

            Vector2 velocity = ball.Rigidbody.velocity;
            rigidbody.velocity = isLeftBall ? rotateVector2(velocity, 110) : rotateVector2(velocity, -110);

            Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);

            GameController.OnRoundFinished += PrepareDestroy;
        }

        private void PrepareDestroy()
        {
            GameController.OnRoundFinished -= PrepareDestroy;
            Destroy(gameObject);
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time >= timerMaxTime)
                PrepareDestroy();
        }

        private Vector2 rotateVector2(Vector2 v, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);

            return v;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Fireball Contact: " + other.gameObject.name);
            GameObject otherGO = other.gameObject;
            switch (otherGO.tag)
            {
                case "Player":
                    CharacterController cc = otherGO.GetComponent<CharacterController>();
                    if (cc.IsLeftPlayer == isTargetLeft)
                    {
                        cc.ChangeScore(1);
                        PrepareDestroy();
                    }

                    break;
                case "BorderP1":
                case "BorderP2":
                    PrepareDestroy();
                    break;
            }
        }
    }
}