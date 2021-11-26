using FightersScripts;
using UnityEngine;

public class IngramItem : MonoBehaviour
{
    [SerializeField] private bool isMeat;
    [SerializeField] private Rigidbody2D rigidbody;
    private float force = 1000f;
    private bool isTargetLeft;

    public void Init(bool isParentLeft, Ball ball)
    {
        Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreLayerCollision(gameObject.layer, gameObject.layer);

        isTargetLeft = isParentLeft;

        rigidbody.velocity = (isParentLeft ? Vector2.right : Vector2.left) * force;

        GameController.OnRoundFinished += PrepareDestroy;
    }

    private void PrepareDestroy()
    {
        GameController.OnRoundFinished -= PrepareDestroy;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGO = other.gameObject;
        switch (otherGO.tag)
        {
            case "Player":
                CharacterController cc = otherGO.GetComponent<CharacterController>();
                if ((cc is ToddIngramController || cc is ToddIngramBotController)
                    && cc.IsLeftPlayer == isTargetLeft)
                {
                    cc.ChangeScore(isMeat ? 1 : -1);
                    PrepareDestroy();
                }

                break;
            case "BorderP1":
            case "BorderP2":
                PrepareDestroy();
                break;
        }
    }
}