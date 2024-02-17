using System.Collections.Generic;
using UnityEngine;

public class RopeStatic : MonoBehaviour, IRope
{
    public List<GameObject> linksList = new List<GameObject>();

    public bool IsCutted = false;

    public bool CheckForCut()
    {
        if (IsCutted)
            return true;
        foreach (GameObject go in linksList)
        {
            if (go == null)
                IsCutted = true;
        }

        return IsCutted;
    }
}