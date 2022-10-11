using UnityEngine;

public class OuterPoket : BasePocket
{
    [SerializeField] private Vector2 _increaseSize;

    private Vector2 _decreaseSize;

    private void OnEnable()
    {
        _decreaseSize = transform.localScale;
    }

    public override void Enter2D()
    {
        ChangeSize(_increaseSize);
    }

    public override void Exit2D()
    {
        ChangeSize(_decreaseSize);
    }


    private void ChangeSize(Vector2 size)
    {
        transform.localScale = size;
    }

    public override void Interaction(Square square)
    {
        square.ChangeState(StateSquare.InOuterPocket);
    }
}
