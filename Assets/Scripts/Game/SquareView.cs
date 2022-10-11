using UnityEngine;

public class SquareView : MonoBehaviour
{
    private Animator _animator;
    private Square _square;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _square = GetComponent<Square>();
        _square.ShowingAnimation += ShowAnimationSquare;
    }
    private void ShowAnimationSquare(string animationKey)
    {
        _animator.SetTrigger(animationKey);
    }
}
