using UnityEngine;
using UnityEngine.UI;

public class NoteTrigger : MonoBehaviour
{
    public GameObject noteUI; // Arrastra aquí el panel o imagen de la nota
    private bool isPlayerInTrigger = false;

    void Update()
    {
        if (isPlayerInTrigger && Input.GetButtonDown("Jump"))
        {
            noteUI.SetActive(true); // Muestra la nota
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            isPlayerInTrigger = false;
            noteUI.SetActive(false); // Opcional: oculta la nota al salir del trigger
        }
    }
}
