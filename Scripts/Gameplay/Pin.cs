using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] private Sprite _activePin;
    private bool _isActive = false;
    private void Activate()
    {
        if (!_isActive)
        { 
            _isActive = true;
            GetComponent<SpriteRenderer>().sprite = _activePin;
            PlayerScore.Instance.AddScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Default")
        {
            Activate();
            AudioVibrationManager.Instance.PlaySound(AudioVibrationManager.Instance.PinCollision, Random.Range(0.8f, 1.1f));
        }
    }
}
