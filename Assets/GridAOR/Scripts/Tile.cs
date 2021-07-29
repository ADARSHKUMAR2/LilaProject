using System;
using System.Collections;
using System.Collections.Generic;
using GridAOR;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Tile : MonoBehaviour
{
    [SerializeField] private Text _tileNumberText;
    [SerializeField] private Image _tileImage;
    [SerializeField] private Color[] _colors;
    [SerializeField] private Button _tileButton;
    
    private int tileNum;
    public int row { private set; get; }
    public int column{ private set; get; }
 
    public void SetTileData(int num,int rowNum,int columnNum)
    {
        tileNum = num;
        row = rowNum;
        column = columnNum;
        _tileNumberText.text = tileNum.ToString();
    }
    
    private void OnEnable()
    {
        AddButtonListeners();
    }

    /// <summary>
    /// Change the color of selected and adjacent tiles based on AOI
    /// First get AOI from game controller script
    /// </summary>
    private void AddButtonListeners()
    {
        _tileButton.onClick.AddListener(SendSelectedTileInfo);
    }

    private void SendSelectedTileInfo()
    {
        UIManager.Instance.SelectedTileInfo(row,column);
        ChangeColor();
    }

    public void ChangeColor()
    {
        var randomColor = Random.Range(0, _colors.Length);
        _tileImage.color = _colors[randomColor];
        _tileNumberText.enabled = true;
    }

    public void SetDefaultValues()
    {
        _tileImage.color = Color.white;
        _tileNumberText.enabled = false;
    }

    private void OnDisable()
    {
        RemoveButtonListeners();
    }

    private void RemoveButtonListeners()
    {
        _tileButton.onClick.RemoveListener(SendSelectedTileInfo);
    }

}
