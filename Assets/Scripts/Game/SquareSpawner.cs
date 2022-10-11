using System;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public event Action SpawnedSquare;
    private event Action GetedPocketPositions;

    [SerializeField] private Square _prefabSquare;
    [SerializeField] private PocketSpawner _pocketSpawner;
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private InputRaycast _inputRaycast;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Transform _squareContainer;

    private Square _square;
    private List<Vector3> _pocketPositions;
    private List<Square> _spawnedSquares = new List<Square>();


    
    private void Awake()
    {
        _gridGenerator.GridGenerated += GetPcketpositions;
        GetedPocketPositions += SpawnSquareforOuterPoket;
        GetedPocketPositions += SpawnSquareForGridPocket;
    }
    private void OnDisable()
    {
        _gridGenerator.GridGenerated -= GetPcketpositions;
        GetedPocketPositions -= SpawnSquareforOuterPoket;
        GetedPocketPositions -= SpawnSquareForGridPocket;
      
    }

    private void SpawnSquareforOuterPoket()
    {
        _square = Instantiate(_prefabSquare,_squareContainer);
        _inputRaycast.ButtonMouseUp += _square.CheckState;
        _pocketSpawner.SpawnedFirstOuterPoket += _square.GetFirstOuterPoket;
        _spawnedSquares.Add(_square);
        SpawnedSquare?.Invoke();
    }

    private void GetPcketpositions(List<Vector3> vector3)
    {
        _pocketPositions = vector3;
        GetedPocketPositions?.Invoke();
    }

    private void SpawnSquareForGridPocket()
    {
        for (int i = 0; i < _levelData.Level.Count; i++)
        {
            Square square = Instantiate(_prefabSquare,_pocketPositions[_levelData.Level[i].IndexPocket],Quaternion.identity, _squareContainer);
            _spawnedSquares.Add(square);
        }
    }
    public void UnsubscribeSquare()
    {
        if (_square != null)
        {
            _inputRaycast.ButtonMouseUp -= _square.CheckState;
            _pocketSpawner.SpawnedFirstOuterPoket -= _square.GetFirstOuterPoket;
        }
     
    }
    public void DeleteSquare()
    {
        
        for (int i = 0; i < _spawnedSquares.Count; i++)
        {
            Destroy(_spawnedSquares[i].gameObject);
        }
        UnsubscribeSquare();
        _spawnedSquares.Clear();
    }
}
