using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;
    
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseMenu;
    
    private bool isPaused = false;

    private void Awake()
    {
        // Implementar patrón Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Configurar el botón de pausa
            pauseButton.onClick.AddListener(TogglePause);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
            pauseMenu.SetActive(true); // Activar menú de pausa
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            pauseMenu.SetActive(false); // Desactivar menú de pausa
        }
    }

    // Opcional: Pausar con tecla Escape
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}