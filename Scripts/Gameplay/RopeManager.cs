using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public static RopeManager Instance;

    [SerializeField] private List<GameObject> ropeList;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void CheckForCut()
    {
        Invoke("Check", 0.1f);
    }
    private void Check()
    {
        bool _isComplete = true;
        foreach (GameObject rope in ropeList)
        {   
            if (rope.GetComponent<IRope>().CheckForCut() == false)
                _isComplete = false;
        }
        if (_isComplete)
            FindObjectOfType<HUD>().StartTimer();
    }
}
