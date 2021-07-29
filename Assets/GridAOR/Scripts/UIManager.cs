using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridAOR
{
 
    public class UIManager : SingletonBase<UIManager>
    {

        [SerializeField] private MenuController _menuPanel;
        [SerializeField] private GameController _gamePanel;
        [SerializeField] private AlertPopup  _alertPopup;
        
        public void ShowGamePanel(bool value)
        {
            _gamePanel.gameObject.SetActive(value);
            _menuPanel.gameObject.SetActive(!value);
        }

        public void SendMenuData(int num,int aOI)
        {
            _gamePanel.SetData(num,aOI);
        }

        public void SelectedTileInfo(int row,int column)
        {
            _gamePanel.HighlightTiles(row,column);
        }
        
        public void SetAlert(string heading,string body,Action OnClose= null)
        {
            _alertPopup.gameObject.SetActive(true);
            _alertPopup.SetDetails(heading,body);
        }
    }
   
}