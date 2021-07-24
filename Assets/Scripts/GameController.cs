using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject tilePrefab;
    
    private List<int> numbersData;
    private List<Tile> allTiles;

    private void Start()
    {
        allTiles = new List<Tile>();
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

    private void SpawnTiles()
    {
        allTiles = new List<Tile>();
        foreach (var num in numbersData)
        {
            GameObject tile = Instantiate(tilePrefab.gameObject, gridParent.transform, false);
            var tileComp = tile.GetComponent<Tile>();
            tileComp.SetTileData(num);
            allTiles.Add(tileComp);
        }
    }

    private void OnDisable()
    {
        allTiles.Clear();
        numbersData.Clear();
    }
}
