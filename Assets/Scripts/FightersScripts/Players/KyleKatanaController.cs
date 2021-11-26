using Assets.Scripts;
using UnityEngine;

namespace FightersScripts
{
    public class KyleKatanaController : PlayerController
    {
        [SerializeField] private KenKatanaBotController kenPrefab;
        [SerializeField] private Transform kenSpawnPoint;

        public override void Init(bool isLeftPlayer,
            AnimatorOverrideController animatorController,
            ContainerForAbilities cfa, SkillContainer container)
        {
            base.Init(isLeftPlayer, animatorController, cfa, container);

            // instead of ability
            Instantiate(kenPrefab, kenSpawnPoint.position, Quaternion.identity, transform.parent)
                .Init(isLeftPlayer, null, cfa, container);
        }
    }
}