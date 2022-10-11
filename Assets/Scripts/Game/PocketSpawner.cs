using System;
using System.Collections.Generic;
using UnityEngine;

public class PocketSpawner : MonoBehaviour
{
    public event Action<OuterPoket> SpawnedFirstOuterPoket;

    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private Pocket _pocketPrefab;
    [SerializeField] private OuterPoket _outerPocket;
    [SerializeField] private SquareSpawner _squareSpawner;
    [SerializeField] private CheckCorrectAnswer _checkCorrectAnswer;
    [SerializeField] private Transform _parenObjectForPokets;
    [SerializeField] private Transform _parenObjectForOuterPokets;
    [SerializeField] private List<PositionOuterPocket> _positionsOuterPocket;

    private List<OuterPoket> _outerPokets = new List<OuterPoket>();
    private List<Pocket> _pockets = new List<Pocket>();

    private void Awake()
    {
        _gridGenerator.GridGenerated += SpawnPocket;
        _squareSpawner.SpawnedSquare += SpawnOuterPocket;
    }
    private void OnDisable()
    {
        _gridGenerator.GridGenerated -= SpawnPocket;
        _squareSpawner.SpawnedSquare -= SpawnOuterPocket;
    }
    private void SpawnPocket(List<Vector3> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
          Pocket pocket=  Instantiate(_pocketPrefab, positions[i], Quaternion.identity, _parenObjectForPokets);
            _pockets.Add(pocket);
            pocket.PocketFulled += _checkCorrectAnswer.Check;
        }
    }

    private void SpawnOuterPocket()
    {
        for (int i = 0; i < _positionsOuterPocket.Count; i++)
        {
            OuterPoket outerPoket =  Instantiate(_outerPocket, _positionsOuterPocket[i].Position, Quaternion.identity, _parenObjectForOuterPokets);
            _outerPokets.Add(outerPoket);
        }
        SpawnedFirstOuterPoket?.Invoke(_outerPokets[0]);
    }

    public void DestroyPockets()
    {
        for (int i = 0; i < _pockets.Count; i++)
        {
            Destroy(_pockets[i].gameObject);
        }
        for (int i = 0; i < _outerPokets.Count; i++)
        {
            Destroy(_outerPokets[i].gameObject);
        }
        _pockets.Clear();
        _outerPokets.Clear();
    }
}
