using UnityEngine;

public class ActivateAfterDelay : MonoBehaviour
{
    public GameObject objectToActivate; // Arrastra aquí el GameObject que quieres activar
    public float delayInSeconds = 10f;  // Tiempo de espera en segundos

    void Start()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // Asegurarse de que está desactivado al inicio
            Invoke("ActivateObject", delayInSeconds); // Llama a ActivateObject después del delay
        }
    }

    void ActivateObject()
    {
        objectToActivate.SetActive(true); // Activa el GameObject
    }
}