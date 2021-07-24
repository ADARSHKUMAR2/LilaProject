using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{

    [SerializeField] private MenuController _menuPanel;
    [SerializeField] private GameController _gamePanel;

    public void ShowGamePanel(bool value)
    {
        _gamePanel.gameObject.SetActive(value);
        _menuPanel.gameObject.SetActive(!value);
    }

    public void GenerateTile()
    {
        _gamePanel.GenerateTileData();
    }
}
