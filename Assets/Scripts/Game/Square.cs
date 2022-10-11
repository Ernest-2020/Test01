using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public event Action<string> ShowingAnimation;
    private Action GetedOuterPoket;
    private OuterPoket _firstOuterPoket;
    private StateSquare _stateSquare;



    private void OnEnable()
    {
        GetedOuterPoket += SquadeMoveStartPosition;
        _stateSquare = new StateSquare();
    }

    private void OnDisable()
    {
        GetedOuterPoket -= SquadeMoveStartPosition;
    }
    
    public void MoveSquare(Vector3 position, StateSquare state )
    {
        if (_stateSquare == StateSquare.InPoket) return;
        transform.position = position;
        _stateSquare = state;
    }

    public void GetFirstOuterPoket(OuterPoket outerPoket)
    {
        _firstOuterPoket = outerPoket;
        GetedOuterPoket?.Invoke();
    }

    public void ShowAnimation(string animationKey)
    {
        ShowingAnimation?.Invoke(animationKey);
    }
    
    public void CheckState()
    {
        StartCoroutine(CoroutineCheckState());
    }

    private IEnumerator CoroutineCheckState()
    {
        yield return new WaitForSeconds(0.1f);
        if (_stateSquare==StateSquare.Move)
        {
            SquadeMoveStartPosition();
        }
    }

    public void ChangeState(StateSquare state)
    {
        _stateSquare = state;
    }
    private void SquadeMoveStartPosition()
    {
        transform.position = _firstOuterPoket.transform.position;
        _stateSquare = StateSquare.InOuterPocket;
    }
}

public enum StateSquare
{
    InPoket,InOuterPocket,Move
}

