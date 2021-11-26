using System.Threading;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace FightersScripts
{
    public class ToddIngramController : PlayerController
    {
        [SerializeField] private IngramItem meatPrefab, vegetablePrefab;
        [SerializeField] private Transform throwPos;
        private float vegetableChance = 0.7f;
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
            if (Random.Range(0f, 1f) < vegetableChance)
                Instantiate(vegetablePrefab, throwPos.position, Quaternion.identity, transform.parent)
                    .Init(isLeftPlayer, ball);
            else
                Instantiate(meatPrefab, throwPos.position, Quaternion.identity, transform.parent)
                    .Init(isLeftPlayer, ball);
        }
    }
}