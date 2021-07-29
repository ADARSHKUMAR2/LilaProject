using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertPopup : SingletonBase<AlertPopup>
{
    [SerializeField] private Text _headingText;
    [SerializeField] private Text _msgText;
    [SerializeField] private Button _okButton;
    
    private Action _OnCloseBtnClick;

    private void OnEnable()
    {
        AddListener();
    }

    private void AddListener()
    {
        _okButton.onClick.AddListener(_CloseBtnClicked);   
    }

    private void OnDisable()
    {
        RemoveListener();
    }

    private void RemoveListener()
    {
        _okButton.onClick.RemoveListener(_CloseBtnClicked);  
    }

    public void SetDetails(string heading,string body, Action OnCloseBtnClick = null)
    {
        gameObject.SetActive(true);
        _headingText.text = heading;
        _msgText.text = body;
        _OnCloseBtnClick = OnCloseBtnClick;
    }
    
    private void _CloseBtnClicked()
    {
        Debug.Log($"Close Button Clicked");
        _headingText.text = _msgText.text = string.Empty;
        _OnCloseBtnClick?.Invoke();
        _OnCloseBtnClick = null;
        gameObject.SetActive(false);
    }
    
}
