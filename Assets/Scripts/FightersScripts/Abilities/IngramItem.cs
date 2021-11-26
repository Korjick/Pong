using UnityEngine;

public class IngramItem : MonoBehaviour
{
    [SerializeField] private bool isMeat;
    [SerializeField] private Rigidbody2D rigidbody;
    private bool isTargetLeft;

    public void Init(bool isParentLeft)
    {
        isTargetLeft = !isParentLeft;

        rigidbody.velocity = isParentLeft ? Vector2.right : Vector2.left;

        GameController.OnRoundFinished += PrepareDestroy;
    }

    private void PrepareDestroy()
    {
        GameController.OnRoundFinished -= PrepareDestroy;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Fireball Contact: " + other.gameObject.name);
        GameObject otherGO = other.gameObject;
        switch (otherGO.tag)
        {
            case "Player":
                CharacterController cc = otherGO.GetComponent<CharacterController>();
                if (cc.IsLeftPlayer == isTargetLeft)
                    cc.GetDamage();
                break;
            case "BorderP1":
            case "BorderP2":
                PrepareDestroy();
                break;
        }
    }
}