using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private CheckCorrectAnswer _checkCorrectAnswer;
    [SerializeField] private TextMeshProUGUI _finishTMP;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private string _correctAnswer;
    [SerializeField] private string _uncorrectAnswer;
    [SerializeField] private string _animationKey;
    [SerializeField] private float _delayShowFinishDisplay;

    private void Awake()
    {
        _checkCorrectAnswer.CheckedAnswer += ShowFinishDisplay;
    }

    private void OnDisable()
    {
        _checkCorrectAnswer.CheckedAnswer -= ShowFinishDisplay;
    }

    private void ShowFinishDisplay(List<Square> squares)
    {
        StartCoroutine(CoroutineShowFinishDisplay(squares));
    }

    private IEnumerator CoroutineShowFinishDisplay(List<Square> squares)
    {
        if (squares!=null)
        {
            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].ShowAnimation(_animationKey);
            }
            yield return new WaitForSeconds(_delayShowFinishDisplay);
            _finishTMP.text = _correctAnswer;
            _finishPanel.gameObject.SetActive(true);
        }
        else
        {
            _finishTMP.text = _uncorrectAnswer;
            _finishPanel.gameObject.SetActive(true);
        }
    }
}
