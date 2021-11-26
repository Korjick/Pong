using System.Threading;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace FightersScripts
{
    public class MatthewPatelBotController : NormalBotController
    {
        [SerializeField] private Vector2 rangeForRandomAbilityUse = new Vector2(3f, 5f);
        private float timerMaxTime, time;
        [SerializeField] private FireBall fireBallPrefab;
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
            Instantiate(fireBallPrefab, ball.transform.position, Quaternion.identity, transform)
                .Init(ball, true, isLeftPlayer);
            Instantiate(fireBallPrefab, ball.transform.position, Quaternion.identity, transform)
                .Init(ball, false, isLeftPlayer);
        }

        [CustomEditor(typeof(MatthewPatelBotController))]
        public class MPBCEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                if (GUILayout.Button("Use Ability"))
                    ((MatthewPatelBotController)target).UseAbility();
            }
        }
    }
}