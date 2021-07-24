using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject tilePrefab;
    
    private List<int> numbersData;
    private Tile[,] allTiles;
    public int xDim;
    public int yDim;

    private void Start()
    {
        allTiles = new Tile[xDim,yDim];
    }

    public void GenerateTileData(int numOfTiles)
    {
        numbersData = new List<int>();
        for (int i = 1; i <= numOfTiles; i++)
        {
            if(!numbersData.Contains(i))
                numbersData.Add(i);
        }
        SpawnTiles();
    }

    /*private Vector2 GetWorldPos(int x, int y)
    {
        var position = transform.position;
        return new Vector2(position.x - xDim/2.0f + x, 
            position.y + yDim/2.0f - y);
    }*/
    private void SpawnTiles()
    {
        // var screenWidth =Screen.width;
        // var gridLayout = GetComponentInChildren<GridLayoutGroup>();
        // gridLayout.cellSize = new Vector2(screenWidth / gridLayout.constraintCount, gridLayout.cellSize.y);
        
        // foreach (var num in numbersData)
        // {
        //     GameObject tile = Instantiate(tilePrefab.gameObject, gridParent.transform, false);
        //     var tileComp = tile.GetComponent<Tile>();
        //     // tileComp.SetTileData(num);
        //     // allTiles.Add(tileComp);
        // }

        for (int i = 0; i < numbersData.Count; i++)
        {
            GameObject tile = Instantiate(tilePrefab.gameObject, gridParent.transform, false);
            var tileComp = tile.GetComponent<Tile>();
        }
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
    

    private void OnDisable()
    {
        // allTiles.Clear();
        numbersData.Clear();
    }
}
