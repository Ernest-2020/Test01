using UnityEngine;
using System;

[Serializable]
public class Level
{
    [SerializeField] private byte _indexPocket;

    public byte IndexPocket => _indexPocket;
}
