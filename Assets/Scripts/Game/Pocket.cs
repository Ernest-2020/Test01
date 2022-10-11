using System;
using UnityEngine;

public class Pocket : BasePocket
{
    public event Action<Pocket,Square> PocketFulled;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _enterColor;

    private Color _exitColor;

    private void OnEnable()
    {
       
        _exitColor = _spriteRenderer.color;
    }
    public override void Enter2D()
    {
        ChangeColor(_enterColor);
    }

    public override void Exit2D()
    {
        ChangeColor(_exitColor);
    }


    private void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;  
    }

    public override void Interaction(Square square)
    {
        square.ChangeState(StateSquare.InPoket);
        PocketFulled?.Invoke(this, square);
        
    }
}
