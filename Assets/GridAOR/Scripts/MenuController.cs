using System;
using System.Collections;
using System.Collections.Generic;
using GridAOR;
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
        if (_numberOfTiles.text.Length == 0 || _areaOfInterest.text.Length == 0)
        {
            UIManager.Instance.SetAlert("Error","Please fill all the fields");
            return;
        }
        
        UIManager.Instance.ShowGamePanel(true);
        UIManager.Instance.SendMenuData(Int32.Parse(_numberOfTiles.text),Int32.Parse(_areaOfInterest.text));
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
