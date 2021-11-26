using System.Threading;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace FightersScripts
{
    public class MatthewPatelController : PlayerController
    {
        [SerializeField] private FireBall fireBallPrefab;
        private Ball ball;

        public override void Init(bool isLeftPlayer,
            AnimatorOverrideController animatorController,
            ContainerForAbilities cfa, SkillContainer container)
        {
            base.Init(isLeftPlayer, animatorController, cfa, container);
            ball = cfa.Ball;
        }

        protected override void UseAbility()
        {
            Instantiate(fireBallPrefab, ball.transform.position, Quaternion.identity, transform.parent)
                .Init(ball, true, isLeftPlayer);
            Instantiate(fireBallPrefab, ball.transform.position, Quaternion.identity, transform.parent)
                .Init(ball, false, isLeftPlayer);
        }
    }
}