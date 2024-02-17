using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;

    private EdgeCollider2D _edgeCollider;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _edgeCollider = GetComponent<EdgeCollider2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        _edgeCollider.enabled = false;
    }
    public void Cut(Vector3 startPoint, Vector3 endPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(startPoint, endPoint);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Link")
            {
                Destroy(collider.gameObject);

                var particle = Instantiate(_particlePrefab);

                particle.transform.position = collider.gameObject.transform.position;

                AudioVibrationManager.Instance.PlaySound(AudioVibrationManager.Instance.CutSound, Random.Range(0.8f, 1.1f));
            }
        }
        RopeManager.Instance.CheckForCut();
    }
    private void Undo()
    { 
        _edgeCollider.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Link"))
        { 
            Destroy(collision.gameObject);
        }
    }
}
