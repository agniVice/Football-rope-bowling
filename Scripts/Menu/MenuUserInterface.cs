using UnityEngine;
using UnityEngine.UI;

public class MenuUserInterface : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _settingsPanel;

    [Header("Settings")]
    [SerializeField] private Button _soundToggle;
    [SerializeField] private Button _musicToggle;
    [SerializeField] private Button _vibrationToggle;

    [SerializeField] private Sprite _soundEnabled;
    [SerializeField] private Sprite _soundDisabled;

    [SerializeField] private Sprite _musicEnabled;
    [SerializeField] private Sprite _musicDisabled;

    [SerializeField] private Sprite _vibrationEnabled;
    [SerializeField] private Sprite _vibrationDisabled;

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        AudioVibrationManager.Instance.SoundChanged += UpdateSoundImage;
        AudioVibrationManager.Instance.MusicChanged += UpdateMusicImage;
        AudioVibrationManager.Instance.VibrationChanged += UpdateVibrationImage;

        _soundToggle.onClick.AddListener(AudioVibrationManager.Instance.ToggleSound);
        _musicToggle.onClick.AddListener(AudioVibrationManager.Instance.ToggleMusic);
        _vibrationToggle.onClick.AddListener(AudioVibrationManager.Instance.ToggleVibration);

        UpdateSoundImage();
        UpdateMusicImage();
        UpdateVibrationImage();

        _menuPanel.SetActive(true);
        _levelsPanel.SetActive(false);
        _settingsPanel.SetActive(false);

    }
    private void OnDisable()
    {
        AudioVibrationManager.Instance.SoundChanged -= UpdateSoundImage;
        AudioVibrationManager.Instance.MusicChanged -= UpdateMusicImage;
        AudioVibrationManager.Instance.VibrationChanged -= UpdateVibrationImage;
    }
    private void UpdateSoundImage()
    {
        if (AudioVibrationManager.Instance.IsSoundEnabled) 
            _soundToggle.GetComponent<Image>().sprite = _soundEnabled;
        else
            _soundToggle.GetComponent<Image>().sprite = _soundDisabled;
    }
    private void UpdateMusicImage()
    {
        if (AudioVibrationManager.Instance.IsMusicEnabled)
            _musicToggle.GetComponent<Image>().sprite = _musicEnabled;
        else
            _musicToggle.GetComponent<Image>().sprite = _musicDisabled;
    }
    private void UpdateVibrationImage()
    {
        if (AudioVibrationManager.Instance.IsVibrationEnabled)
            _vibrationToggle.GetComponent<Image>().sprite = _vibrationEnabled;
        else
            _vibrationToggle.GetComponent<Image>().sprite = _vibrationDisabled;
    }
    public void OnSettingsButtonClicked()
    {
        _menuPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }
    public void OnCloseSettingsButtonClicked()
    {
        _menuPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }
    public void OnCloseLevelsButtonClicked()
    {
        _menuPanel.SetActive(true);
        _levelsPanel.SetActive(false);
    }
    public void OnLevelsButtonClicked()
    {
        _menuPanel.SetActive(false);
        _levelsPanel.SetActive(true);
    }
    public void OnExitButtonClicked()
    { 
        Application.Quit();
    }
}
