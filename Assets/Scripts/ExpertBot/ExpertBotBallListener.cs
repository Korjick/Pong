using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExpertBotBallListener : MonoBehaviour
    {
        public float PosY { get; private set; }
        public bool IsAiming { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Ball"))
            {
                IsAiming = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Ball"))
            {
                PosY = other.transform.position.y;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Ball"))
            {
                IsAiming = false;
            }
        }
    }
}