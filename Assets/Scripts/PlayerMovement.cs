using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool invertControls;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Verifica si la escena actual es "El Mundo Al Revés"
        invertControls = SceneManager.GetActiveScene().name == "RoominvertedC";
    }

    void Update()
    {
        Vector2 finalInput = invertControls ? -moveInput : moveInput;
        rb.linearVelocity = finalInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
