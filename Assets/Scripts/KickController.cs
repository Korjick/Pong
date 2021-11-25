using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class KickController : MonoBehaviour
    {
        [SerializeField] private Transform kickPlace;
        private List<Transform> balls = new List<Transform>();
        private float kickMultiplier = 10f;

        public void Kick()
        {
            foreach (Transform ball in balls)
            {
                ball.GetComponent<Rigidbody2D>().AddForce((ball.position - kickPlace.position) * kickMultiplier);
                Debug.Log("Kicked ball " + ball.gameObject.name);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Enter " + other.name);
            if (other.tag.Equals("Ball"))
            {
                balls.Add(other.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag.Equals("Ball"))
            {
                balls.Remove(other.transform);
            }
        }
    }
}