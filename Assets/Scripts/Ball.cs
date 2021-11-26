using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private int thrust;

    private int _beatCount;
    private Rigidbody2D _rigidbody;
    private Image image;

    public Rigidbody2D Rigidbody => _rigidbody;
    public Image Image => image;

    private void Awake()
    {
        _beatCount = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        image = GetComponent<Image>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Border")) _beatCount++;
        else _beatCount = 0;

        if (_beatCount >= 10)
            RandomForce();
    }

    public void RandomForce()
    {
        var right = Random.Range(-1, 1) == 0 ? 1 : -1;
        _rigidbody.AddForce(
            new Vector2(right * Random.Range(2, 6), Random.Range(2, 7)) * thrust, ForceMode2D.Force);
    }
}