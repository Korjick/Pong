using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NormalBotController : CharacterController
{
    [SerializeField] private Vector2 rangeForRandomAbilityUse = new Vector2(3f, 5f);
    private float timerMaxTime, time;
    private Vector2 botMove = Vector2.up;
    private float moveDelta = 5f;

    private void Start()
    {
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