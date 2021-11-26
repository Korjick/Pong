using System;
using System.Collections;
using UnityEngine;

namespace FightersScripts.Abilities
{
    public class LiWall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag.Equals("Ball"))
            {
                Destroy(gameObject);
            }
        }
    }
}