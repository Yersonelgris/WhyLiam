using UnityEngine;
using TMPro;

public class ShowCredits : MonoBehaviour
{
    public GameObject uiImage;
    public TMP_Text tmpText;
    public float delay = 25f;

    void Start()
    {
        // Desactiva los elementos al inicio
        if (uiImage != null) uiImage.SetActive(false);
        if (tmpText != null) tmpText.gameObject.SetActive(false);

        // Llama al método ActivateUI después del delay
        Invoke("ActivateUI", delay);
    }

    void ActivateUI()
    {
        // Activa los elementos
        if (uiImage != null) uiImage.SetActive(true);
        if (tmpText != null) tmpText.gameObject.SetActive(true);
    }
}