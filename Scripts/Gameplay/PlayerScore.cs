using System.Collections;
using UnityEngine;

public class PlayerScore : MonoBehaviour, ISubscriber, IInitializable
{
    public static PlayerScore Instance;

    public int Score { get; private set; }
    public int MaxScore;

    private bool _isInitialized;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
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
    public void SubscribeAll()
    {
        GameState.Instance.GameFinished += Save;
    }

    public void UnsubscribeAll()
    {
        GameState.Instance.GameFinished += Save;
    }

    public void Initialize()
    {
        MaxScore = PinManager.Instance.PinCount;
        _isInitialized = true;
    }
    public void AddScore()
    {
        Score++;
        GameState.Instance.ScoreAdded?.Invoke();

        if (Score >= MaxScore)
        {
            GameState.Instance.FinishGame();
        }
    }
    private void Save()
    {
        if (Score > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", Score);
    }
}