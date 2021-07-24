using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private InputField _numberOfTiles;
    [SerializeField] private InputField _areaOfInterest;
    [SerializeField] private Button _nextButton;

    private void OnEnable()
    {
        AddButtonListeners();
    }

    private void AddButtonListeners()
    {
        _nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnNextButtonClick()
    {
        UIManager.Instance.ShowGamePanel(true);
        UIManager.Instance.GenerateTile();
    }

    private void OnDisable()
    {
        RemoveButtonListeners();
    }

    private void RemoveButtonListeners()
    {
        _nextButton.onClick.RemoveListener(OnNextButtonClick);
    }
}
