using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public float sensibilidad = 0.1f;
    private float rotacionX = 0f;
    private float rotacionY = 0f;

    void Start()
    {
        Vector3 rotacionActual = transform.localRotation.eulerAngles;
        rotacionX = rotacionActual.y;
        rotacionY = rotacionActual.x;
    }

    void Update()
    {
        // Verificamos si el botón derecho está presionado
        if (Mouse.current.rightButton.isPressed)
        {
            // Bloquear el cursor
            Cursor.lockState = CursorLockMode.Locked;

            // Leer el valor del movimiento del ratón (Delta)
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            float deltaX = mouseDelta.x * sensibilidad;
            float deltaY = mouseDelta.y * sensibilidad;

            rotacionX += deltaX;
            rotacionY -= deltaY;

            // Limitar rotación vertical
            rotacionY = Mathf.Clamp(rotacionY, -80f, 80f);

            transform.localRotation = Quaternion.Euler(rotacionY, rotacionX, 0f);
        }
        else
        {
            // Liberar el cursor si no se presiona el botón
            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}