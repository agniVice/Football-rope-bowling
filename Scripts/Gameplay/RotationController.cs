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

        // ѕримен€ем силу дл€ вращени€ объекта вокруг центра массы
        rb.AddTorque(rotationAngle);

        // ћен€ем направление поворота при достижении определенного угла (например, 30 градусов)
        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 30f)
        {
            isRotatingRight = !isRotatingRight;
        }
    }
}