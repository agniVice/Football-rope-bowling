using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance;

    public int PinCount;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
}
