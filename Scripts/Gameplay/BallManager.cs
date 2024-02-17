using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    [SerializeField] private List<GameObject> _balls = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else 
            Instance = this;

        FreezeBalls();
    }
    private void OnEnable()
    {
        GameState.Instance.GameStarted += UnFreezeBalls;
    }
    private void OnDisable()
    {
        GameState.Instance.GameStarted -= UnFreezeBalls;
    }
    private void FreezeBalls()
    {
        /*foreach (GameObject ball in _balls)
            ball.GetComponent<Rigidbody2D>().isKinematic = true;*/
    }
    private void UnFreezeBalls()
    {
        foreach (GameObject ball in _balls)
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    public void OnBallUnHooked(Ball ball)
    {
        _balls.Remove(ball.gameObject);

        if (_balls.Count <= 0)
        {
            FindObjectOfType<HUD>().StartTimer();
        }
    }
}
