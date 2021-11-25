using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BordersController : MonoBehaviour
    {
        public event Action<bool> OnGoal;
        [SerializeField] private Border mainBorder, secondBorder;

        private void Start()
        {
            mainBorder.OnBallInBorder += MainBorder_OnBallInBorder;
            secondBorder.OnBallInBorder += SecondBorder_OnBallInBorder;
        }

        private void SecondBorder_OnBallInBorder()
        {
            OnGoal?.Invoke(false);
        }

        private void MainBorder_OnBallInBorder()
        {
            OnGoal?.Invoke(true);
        }
    }
}