using System.Threading;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace FightersScripts
{
    public class ToddIngramBotController : NormalBotController
    {
        [SerializeField] private Vector2 rangeForRandomAbilityUse = new Vector2(3f, 5f);
        private float timerMaxTime, time;
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

            timerMaxTime = Random.Range(rangeForRandomAbilityUse.x, rangeForRandomAbilityUse.y);
        }

        protected override void Update()
        {
            base.Update();

            if (canUseAbility)
            {
                time += Time.deltaTime;
                if (time >= timerMaxTime)
                {
                    time = 0f;
                    UseAbility();
                    timerMaxTime = Random.Range(rangeForRandomAbilityUse.x, rangeForRandomAbilityUse.y);
                }
            }
            else time = 0f;
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