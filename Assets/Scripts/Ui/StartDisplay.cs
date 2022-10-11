using UnityEngine;
using UnityEngine.UI;

public class StartDisplay : MonoBehaviour
{
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private GameObject _startDisplay;

    [SerializeField ]private Button _startButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(_gridGenerator.Generate);
        _startButton.onClick.AddListener(DisableStartDisplay);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(_gridGenerator.Generate);
        _startButton.onClick.RemoveListener(DisableStartDisplay);
    }

    private void DisableStartDisplay()
    {
        _startDisplay.SetActive(false);
    }
}
