using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Nombre exacto de la escena a cargar
    public string nombreEscena = "InitScene";

    void Update()
    {
        // Detectar si se presiona la tecla Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CargarEscena();
        }
    }

    // Método público para llamar desde el botón
    public void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
