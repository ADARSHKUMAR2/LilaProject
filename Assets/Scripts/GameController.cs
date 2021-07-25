using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Button _backButton;
    
    private List<int> numbersData;
    private List<Tile> allTiles;

    private int areaOfInterest=0;
    // public int xDim;
    // public int yDim; 

    private void OnEnable()
    {
        AddButtonListeners();
    }

    private void AddButtonListeners()
    {
        _backButton.onClick.AddListener(OnBackClicked);
    }


    public void SetData(int numOfTiles,int aOI)
    {
        areaOfInterest = aOI;
        numbersData = new List<int>();
        for (int i = 1; i <= numOfTiles; i++)
        {
            if(!numbersData.Contains(i))
                numbersData.Add(i);
        }
        SpawnTiles();
    }

    private void SpawnTiles()
    {
        allTiles = new List<Tile>();
        // var screenWidth =Screen.width;
        var gridLayout = GetComponentInChildren<GridLayoutGroup>();
        // gridLayout.cellSize = new Vector2(screenWidth / gridLayout.constraintCount, gridLayout.cellSize.y);

        int numbers = 1;
        var columns = gridLayout.constraintCount;
        // i-> Row , j-> Column
        for (int i = 0; i < numbersData.Count/columns; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject tile = Instantiate(tilePrefab.gameObject, gridParent.transform, false);
                var tileComp = tile.GetComponent<Tile>();
                tile.name = $"obj-{i},{j}";
                tileComp.SetTileData(numbers,i,j);
                allTiles.Add(tileComp);
                numbers++;
            }
        }
    }

    public void HighlightTiles(int rowNum,int columnNum)
    {
        Debug.Log($"Row - {rowNum} , column - {columnNum}");
        
        for (int i = rowNum - areaOfInterest; i <= rowNum + areaOfInterest; i++)
        {
            for (int j = columnNum - areaOfInterest; j <= columnNum + areaOfInterest; j++)
            {
                // Debug.Log($"{i},{j} \n");
                ColorTile(i,j);
            }
        }
    }

    private void ColorTile(int row,int column)
    {
        foreach (var tile in allTiles)
        {
            if(tile.row == row && tile.column==column)
                tile.ChangeColor();
        }
    }

    private void OnBackClicked()
    {
        ClearData();
        UIManager.Instance.ShowGamePanel(false);
    }

    private void OnDisable()
    {
        ClearData();
        RemoveButtonListeners();
    }

    private void ClearData()
    {
        allTiles.Clear();
        numbersData.Clear();
    }

    private void RemoveButtonListeners()
    {
        _backButton.onClick.RemoveListener(OnBackClicked);
    }
    /*[ContextMenu("Draw Board")]
    public void SpawnTiles()
    {
        for (int i = 0; i < xDim; i++)
        {
            for (int j = 0; j < yDim; j++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(i,j), Quaternion.identity);
                tile.transform.SetParent(gridParent);
            }
        }
    }*/
    
    /*private Vector2 GetWorldPos(int x, int y)
    {
        var position = transform.position;
        return new Vector2(position.x - xDim/2.0f + x, 
            position.y + yDim/2.0f - y);
    }*/

}
