using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int thrust;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 15) * thrust, ForceMode2D.Force);
    }
}
