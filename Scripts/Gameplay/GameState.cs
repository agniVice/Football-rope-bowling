using System;
using System.Security.Cryptography;
using UnityEngine;

public class GameState : MonoBehaviour, IInitializable
{
    public static GameState Instance;

    public Action GameStarted;
    public Action GamePaused;
    public Action GameUnpaused;
    public Action GameFinished;
    public Action GameLosed;

    public Action ScoreAdded;

    public enum State
    { 
        InGame,
        Paused,
        Finished
    }
    public State CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    public void Initialize()
    {

    }
    public void StartGame()
    {
        GameStarted?.Invoke();
        CurrentState = State.InGame;
        Time.timeScale = 1.0f;
    }
    public void PauseGame()
    {
        GamePaused?.Invoke();
        CurrentState = State.Paused;
        Time.timeScale = 0.0f;
    }
    public void UnpauseGame()
    {
        GameUnpaused?.Invoke();
        CurrentState = State.InGame;
        Time.timeScale = 1.0f;
    }
    public void FinishGame()
    {
        GameFinished?.Invoke();
        CurrentState = State.Finished;

        AudioVibrationManager.Instance.PlaySound(AudioVibrationManager.Instance.Win, 1f);

        PlayerPrefs.SetInt("LevelLocked" + (LevelManager.Instance.CurrentLevelId+1) , 0);

        //if (AudioVibrationManager.Instance.IsVibrationEnabled)
            //Handheld.Vibrate();
    }
    public void LoseGame()
    {
        GameLosed?.Invoke();
        CurrentState = State.Finished;

        AudioVibrationManager.Instance.PlaySound(AudioVibrationManager.Instance.Wrong, 1f);

        //if (AudioVibrationManager.Instance.IsVibrationEnabled)
            //Handheld.Vibrate();
    }
}