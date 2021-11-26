using UnityEngine;

public class NormalBotController : CharacterController
{
    private Vector2 botMove = Vector2.up;
    private float moveDelta = 5f;

    protected override void Movement()
    {
        base.Movement();

        isMoving = false;

        float y = cfa.Ball.transform.position.y;

        if (transform.position.y < y - moveDelta)
        {
            botMove = Vector2.up;
            isMoving = true;
        }
        else if (transform.position.y > y + moveDelta)
        {
            botMove = Vector2.down;
            isMoving = true;
        }
        else botMove = Vector2.zero;

        _rigidbody.velocity = botMove * force;
    }
}