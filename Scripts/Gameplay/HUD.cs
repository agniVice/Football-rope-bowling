using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour, IInitializable, ISubscriber
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _levelNumberText;
    [SerializeField] private TextMeshProUGUI _pins;

    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _isInitialized;
    private bool _isTimerWork;

    private float _timeForLose = 5f;

    private void OnEnable()
    {
        if (!_isInitialized)
            return;

        SubscribeAll();
    }
    private void OnDisable()
    {
        UnsubscribeAll();
    }
    private void FixedUpdate()
    {
        if(GameState.Instance.CurrentState == GameState.State.InGame)
        {
            if (_isTimerWork)
            {
                _timeForLose -= Time.fixedDeltaTime;

                _timerText.text = _timeForLose.ToString("F0");

                if(_timeForLose < 0 )
                {
                    _isTimerWork = false;
                    GameState.Instance.LoseGame();
                }
            }
        }
    }
    public void Initialize()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        Show();

        _levelNumberText.text = "LEVEL: " + LevelManager.Instance.CurrentLevelId;
        _timerText.text = _timeForLose.ToString("F0");

        UpdatePins();

        _isInitialized = true;
    }
    public void SubscribeAll()
    {
        GameState.Instance.GameLosed += Hide;
        GameState.Instance.GameFinished += Hide;
        GameState.Instance.GamePaused += Hide;
        GameState.Instance.GameUnpaused += Show;

        GameState.Instance.ScoreAdded += UpdatePins;
    }
    public void UnsubscribeAll()
    {
        GameState.Instance.GameLosed -= Hide;
        GameState.Instance.GameFinished -= Hide;
        GameState.Instance.GamePaused -= Hide;
        GameState.Instance.GameUnpaused -= Show;

        GameState.Instance.ScoreAdded -= UpdatePins;
    }
    private void Show()
    {
        _panel.SetActive(true);
    }
    private void Hide()
    {
        _panel.SetActive(false);
    }
    private void UpdatePins()
    {
        _pins.text = PlayerScore.Instance.Score + " | " + PlayerScore.Instance.MaxScore;
    }
    public void OnRestartButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Gameplay");
    }
    public void OnButtonPauseClicked()
    {
        GameState.Instance.PauseGame();
    }
    public void OnExitButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Menu");
    }
    public void StartTimer()
    {
        _isTimerWork = true;
    }
}