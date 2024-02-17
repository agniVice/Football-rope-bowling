using UnityEngine;

public class RotationController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isRotatingRight = true;
    public float rotationSpeed = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float rotationAngle = isRotatingRight ? rotationSpeed : -rotationSpeed;

        // ��������� ���� ��� �������� ������� ������ ������ �����
        rb.AddTorque(rotationAngle);

        // ������ ����������� �������� ��� ���������� ������������� ���� (��������, 30 ��������)
        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 30f)
        {
            isRotatingRight = !isRotatingRight;
        }
    }
}