using System;
using UnityEngine;

[Serializable]
public class PositionOuterPocket
{
    [SerializeField] Vector2 _position;

    public Vector2 Position => _position;
}
