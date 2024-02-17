using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour, IRope
{

    public Rigidbody2D hook;

    public GameObject linkPrefab;

    public Weight weigth;

    public int links = 7;

    public List<GameObject> linksList = new List<GameObject>();

    public bool IsCutted = false;

    void Start()
    {
        GenerateRope();
    }
    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            //link.transform.parent = transform;
            linksList.Add(link);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }
    public bool CheckForCut()
    {
        if (IsCutted)
            return true;
        foreach(GameObject go in linksList)
        {
            if (go == null)
                IsCutted = true;
        }

        return IsCutted;
    }
}