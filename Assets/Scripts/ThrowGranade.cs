using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowGranade : MonoBehaviour
{
    [Header("Configuración de Lanzamiento")]
    public float force = 15f;
    public Transform puntoSalida; // Un objeto vacío frente a la cámara

    public GameObject[] cubos;
    public Transform[] posiciones;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();


    }

    public void Retry()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        transform.SetParent(puntoSalida);
        transform.localPosition = Vector3.zero;
        transform.localRotation = new Quaternion(0, 0, 0, 0);
        gameObject.SetActive(true);

        for (int i = 0; i < cubos.Length; i++)
        {
            cubos[i].GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            cubos[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            cubos[i].GetComponent<Transform>().SetParent(posiciones[i]);
            cubos[i].GetComponent<Transform>().localPosition = Vector3.zero;
            cubos[i].GetComponent<Transform>().localRotation = new Quaternion(0,0,0,0);


        }
    }

    public void Play()
    {

        // Empezamos con el balón quieto y sin gravedad
        rb.useGravity = true;
        // Desvinculamos del padre
        transform.SetParent(null);

        // Calculamos la dirección (el forward de la cámara principal)
        Vector3 direccion = Camera.main.transform.forward;
        //direccion.y = direccion.y + 1f;

        // Aplicamos la fuerza (Impulse es ideal para lanzamientos instantáneos)
        rb.AddForce(direccion * force, ForceMode.Impulse);
        rb.AddTorque(Camera.main.transform.right, ForceMode.Impulse);
    }
}
