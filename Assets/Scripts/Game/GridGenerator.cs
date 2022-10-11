using System;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public event Action<List<Vector3>> GridGenerated;

    [SerializeField] private byte _width;
    [SerializeField] private byte _height;
    [SerializeField] private Vector2 _startPositionGrid;
    [SerializeField] private Vector2 _spaseCell;

    private List<Vector3> _cellPositions = new List<Vector3>();

    public void Generate()
    {
        for (byte i = 0; i < _width; i++)
        {
            for (byte j = 0; j < _height; j++)
            {
                _cellPositions.Add(new Vector3((i + _startPositionGrid.x)* _spaseCell.x, (j + _startPositionGrid.y)* _spaseCell.y));
            }
        }
        GridGenerated?.Invoke(_cellPositions);
    }

    public void ClearCellPositions()
    {
        _cellPositions.Clear();
    }
}
