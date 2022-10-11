using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckCorrectAnswer : MonoBehaviour
{
    public event Action<List<Square>> CheckedAnswer;

    [SerializeField] private SquareSpawner _squareSpawner;
    [SerializeField] private byte _maxSquare;

    private byte _currenNumbertSquare;
    
    public void Check(Pocket pocket,Square square)
    {
        _currenNumbertSquare++;
        if (_currenNumbertSquare >= _maxSquare)
        {
            CheckedAnswer?.Invoke(FindSquare(square));
            _currenNumbertSquare = 0;
        }
        pocket.PocketFulled -= Check;
    }

    private List<Square> FindSquare(Square square)
    {
        List<Square> identicalPositionSquares = new List<Square> ();
        Vector2[] directionRays = new Vector2[] { Vector2.left, Vector2.right };
        Collider2D  squareCollider = square.gameObject.GetComponent<Collider2D>();
        squareCollider.enabled = false;
        for (int i = 0; i < directionRays.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(square.transform.position, directionRays[i]);
            if (hit.collider != null && hit.collider.TryGetComponent(out Square hitsSquare))
            {
                if (hitsSquare.transform.position.y == square.transform.position.y)
                {
                    identicalPositionSquares.Add(hitsSquare);
                }
            }
            
            Debug.DrawRay(square.transform.position, directionRays[i], Color.red, 100, true);
        }
        squareCollider.enabled = false;

        if (identicalPositionSquares.Count==2)
        {
            identicalPositionSquares.Add(square);
           return identicalPositionSquares;
        }
        return null;
    }
}
