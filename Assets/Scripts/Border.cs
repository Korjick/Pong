using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Border : MonoBehaviour
    {
        public event Action OnBallInBorder;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag.Equals("Ball")) 
                OnBallInBorder?.Invoke();
        }
    }
}