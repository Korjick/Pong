using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class FighterButton : MonoBehaviour
{
    public event Action<FighterSO> OnButtonSelected;
    [SerializeField] private Button button;
    [SerializeField] private Image icon;
    [SerializeField] private Text name;
    private FighterSO fighterSO;

    private void Start()
    {
        button.onClick.AddListener(Button_OnClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Button_OnClick);
    }

    public void SetSO(FighterSO fighterSO)
    {
        this.fighterSO = fighterSO;
    }

    private void Button_OnClick()
    {
        OnButtonSelected?.Invoke(fighterSO);
    }
}