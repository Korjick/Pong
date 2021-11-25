using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContainer : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private Transform _progress;
    [SerializeField] private bool _isLeft = true;

    private int _idx;

    private void OnEnable() 
        => PlayerController.BallKicked += OnBallKicked;

    private void OnBallKicked(bool b)
    {
        if(_isLeft == b)
            OpenProgress();
    }

    private void Awake() => _idx = 0;

    private void OpenProgress()
    {
        if(_idx == 4)
            _key.SetActive(true);
        if(_idx < 0 || _idx > 3)
            return;
        _progress.GetChild(_idx).gameObject.SetActive(true);
        _idx++;
    }

    private void CloseAllProgress()
    {
        _key.SetActive(false);
        for (int i = 0; i < _progress.childCount; i++)
            _progress.GetChild(i).gameObject.SetActive(false);
    }
}
