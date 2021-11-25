using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private int thrust;

    private int _beatCount;
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;
    
    private void Awake()
    {
        _beatCount = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Border")) _beatCount++;

        if (_beatCount <= 9) return;
        _beatCount = 0;
        RandomForce();
    }

    public void RandomForce()
    {
        var right = Random.Range(-1, 1) == 0 ? 1 : -1;
        _rigidbody.AddForce(
            new Vector2(right * Random.Range(10, 40), Random.Range(5, 16)) * thrust, ForceMode2D.Force);
    }
}
