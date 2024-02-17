using UnityEngine;

public class Ball : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            if (GameState.Instance.CurrentState != GameState.State.Finished || GameState.Instance.CurrentState != GameState.State.Paused)
            {
                GameState.Instance.LoseGame();
            }
        }
    }
}
