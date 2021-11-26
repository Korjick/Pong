using UnityEngine;

namespace Assets.Scripts
{
    public class ContainerForAbilities : MonoBehaviour
    {
        [SerializeField] private Ball ball;
        public Ball Ball => ball;
    }
}