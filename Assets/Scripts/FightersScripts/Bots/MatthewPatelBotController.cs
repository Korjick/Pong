using System.Threading;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

namespace FightersScripts
{
    public class MatthewPatelBotController : BotController
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