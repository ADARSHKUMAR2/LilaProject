using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    private GameController _gameController;
    public float cameraOffset;
    private float padding = 2f;
    private float aspectRatio = 0.625f;
    /*private void Start()
    {
        // Debug.Log($"Screen width - {Screen.width} , Height - {Screen.height}");
        _gameController = FindObjectOfType<GameController>();
        if(_gameController!=null)
            RepositionCamera(_gameController.xDim - 1,_gameController.yDim - 1);
    }

    private void RepositionCamera(float x, float y)
    {
        Vector3 tempPos = new Vector3(x/2, y/2,cameraOffset);
        transform.position = tempPos;
        
        //Change orthographic size
        if (_gameController.xDim >= _gameController.yDim)
            Camera.main.orthographicSize = (_gameController.xDim / 2 + padding) / aspectRatio;
        // else
        //     Camera.main.orthographicSize = _gameController.yDim / 2 + padding;
    }*/
}
