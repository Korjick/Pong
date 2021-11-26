using UnityEngine;

namespace Assets.Scripts
{
    public class ContainerForAbilities : MonoBehaviour
    {
        [SerializeField] private Ball ball;
        [SerializeField] private GameObject background;
        public Ball Ball => ball;
        public GameObject Background => background;
    }
}