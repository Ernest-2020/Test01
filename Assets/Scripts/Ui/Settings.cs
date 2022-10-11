using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitSettinsButton;
    [SerializeField] private GameObject _settingsPanel;

    private void Awake()
    {
        _settingsButton.onClick.AddListener(ShowSettings);
        _exitSettinsButton.onClick.AddListener(HideSettings);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(ShowSettings);
        _exitSettinsButton.onClick.RemoveListener(HideSettings);
    }

    private void ShowSettings()
    {
        _settingsPanel.SetActive(true);
    }

    private void HideSettings()
    {
        _settingsPanel.SetActive(false);
    }
}
