using UnityEngine;

public class RopeCutter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _scissors;
    [SerializeField] private SpriteRenderer _endPointSprite;
    [SerializeField] private LineRenderer _lineRenderer;
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private bool _isDragging = false;

    private void Start()
    {
        _scissors.color = new Color32(255, 255, 255, 0);
        _endPointSprite.color = new Color32(255,255,255,0);
    }
    private void Update()
    {
        if (GameState.Instance.CurrentState != GameState.State.InGame)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!_isDragging)
            {
                _isDragging = true;
                _startPoint = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                _scissors.color = new Color32(255, 255, 255, 255);
                _endPointSprite.color = new Color32(255, 255, 255, 255);

                _scissors.transform.position = _startPoint;

                _lineRenderer.SetPosition(0, _startPoint);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (_isDragging)
            {
                _isDragging = false;
                _scissors.color = new Color32(255, 255, 255, 0);
                _endPointSprite.color = new Color32(255, 255, 255, 0);

                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);

                _lineRenderer.GetComponent<Cutter>().Cut(_startPoint, _endPoint);
            }
        }
        if (_isDragging)
        {
            Vector3 currentMousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            _endPoint = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            _scissors.transform.up = (_endPoint -_startPoint).normalized;

            _endPointSprite.transform.position = currentMousePos;

            _lineRenderer.SetPosition(1, _endPoint);
        }
    }
}