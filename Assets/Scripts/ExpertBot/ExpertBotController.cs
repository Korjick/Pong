using UnityEngine;

namespace Assets.Scripts
{
    public class ExpertBotController : BotController
    {
        [SerializeField] private ExpertBotBallListener listener;

        protected override void Movement()
        {
            if (listener.IsAiming)
            {
                var pos = transform.position;
                pos.y = listener.PosY;
                transform.position = pos;
            }
            else base.Movement();
        }
    }
}