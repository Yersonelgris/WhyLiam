using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject notePanel;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool invertControls;
    private Vector2 lastMoveDirection = Vector2.down;
    private Animator animator;
    private GameObject mirror;
    private bool noteNearby = false;

    public AudioSource bossSound;

    private bool hasTriggeredBoss = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        string sceneName = SceneManager.GetActiveScene().name;
        invertControls = sceneName == "MirrorScene" || sceneName == "Roominverted";

        if (sceneName == "MirrorScene")
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerMirror");
        }
        else if (sceneName == "Roominverted")
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PlayerMirror");
        }
        else
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Player");
        }

        if (notePanel != null)
        {
            notePanel.SetActive(false);
        }
    }

    void Update()
    {
        Vector2 finalInput = invertControls ? -moveInput : moveInput;
        rb.linearVelocity = finalInput * moveSpeed;

        Vector2 animDirection = Vector2.zero;
        if (finalInput != Vector2.zero)
        {
            if (Mathf.Abs(finalInput.y) > Mathf.Abs(finalInput.x))
            {
                animDirection = new Vector2(0, finalInput.y);
            }
            else
            {
                animDirection = new Vector2(finalInput.x, 0);
            }

            lastMoveDirection = animDirection;
        }

        animator.SetFloat("Horizontal", animDirection.x);
        animator.SetFloat("Vertical", animDirection.y);
        animator.SetBool("IsMoving", finalInput != Vector2.zero);

        if (Input.GetButtonDown("Jump") && mirror != null)
        {
            SceneManager.LoadScene("MirrorScene");
        }

        if (Input.GetButtonDown("Jump") && noteNearby && notePanel != null)
        {
            notePanel.SetActive(true);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hollow"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Mirror"))
        {
            mirror = collision.gameObject;
        }

        if (collision.CompareTag("Portal1"))
        {
            SceneManager.LoadScene("Roominverted");
        }

        if (collision.CompareTag("Portal2"))
        {
            SceneManager.LoadScene("RoomC");
        }

        if (collision.CompareTag("Portal3"))
        {
            SceneManager.LoadScene("BossC");
        }

        if (collision.CompareTag("Boss") && !hasTriggeredBoss)
        {
            hasTriggeredBoss = true;
            LoadBossScene(); // Primero carga la escena
        }

        if (collision.CompareTag("Note"))
        {
            noteNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            noteNearby = false;
            if (notePanel != null)
            {
                notePanel.SetActive(false);
            }
        }

        if (collision.CompareTag("Mirror"))
        {
            mirror = null;
        }
    }

    void LoadBossScene()
    {
        SceneManager.sceneLoaded += OnBossSceneLoaded;
        SceneManager.LoadScene("SanatoriumC");
    }

    private void OnBossSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SanatoriumC")
        {
            // Buscar el AudioSource en la nueva escena
            AudioSource sceneBossSound = Object.FindFirstObjectByType<AudioSource>();
            if (sceneBossSound != null)
            {
                sceneBossSound.Play();
            }

            // Limpiar el evento
            SceneManager.sceneLoaded -= OnBossSceneLoaded;
        }
    }
}