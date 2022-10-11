using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private SquareSpawner _squareSpawner;
    [SerializeField] private PocketSpawner _pocketSpawner;
    [SerializeField] private CheckCorrectAnswer _checkCorrectAnswer;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _startDisplay;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(_squareSpawner.DeleteSquare);
        _restartButton.onClick.AddListener(_pocketSpawner.DestroyPockets);
        _restartButton.onClick.AddListener(_gridGenerator.ClearCellPositions);
        _restartButton.onClick.AddListener(EnableStartDisplay);
        _restartButton.onClick.AddListener(DisableFinishPanel);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveAllListeners();
    }
    private void EnableStartDisplay()
    {
        _startDisplay.SetActive(true);
    }
    private void DisableFinishPanel()
    {
        _finishPanel.SetActive(false);
    }

}
