using UnityEngine;

public abstract class BasePocket : MonoBehaviour
{

    public byte CountSquareInPocket { get; private set; }

    private byte _maxCountInPoket = 1;

    private void OnEnable()
    {
        CountSquareInPocket = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Square square)&&!Input.GetMouseButton(0)&&CountSquareInPocket== _maxCountInPoket)
        {
            square.MoveSquare(transform.position, StateSquare.InPoket);
            Interaction(square);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Square>() )
        {
            Enter2D();
            CountSquareInPocket++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Square>() && CountSquareInPocket == _maxCountInPoket)
        {
            Exit2D();
            CountSquareInPocket--;

        }
    }

    public abstract void Interaction(Square square);
    public abstract void Enter2D();
    public abstract void Exit2D();
}
