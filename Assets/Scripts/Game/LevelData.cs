using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewLevel", menuName = "Game/" + nameof(LevelData), order = 0)]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<Level> _level;

    public IReadOnlyList<Level> Level => _level;
}
