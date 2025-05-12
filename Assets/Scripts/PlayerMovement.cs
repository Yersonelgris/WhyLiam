using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool invertControls;
    private Vector2 lastMoveDirection = Vector2.down;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        invertControls = SceneManager.GetActiveScene().name == "mirrorScene";
    }

    void Update()
    {
        Vector2 finalInput = invertControls ? -moveInput : moveInput;
        rb.linearVelocity = finalInput * moveSpeed;

        // Prioriza direcciones
        Vector2 animDirection = Vector2.zero;
        if (finalInput != Vector2.zero)
        {
            if (Mathf.Abs(finalInput.y) > Mathf.Abs(finalInput.x))
            {
                // Prioriza movimiento vertical
                animDirection = new Vector2(0, finalInput.y);
            }
            else
            {
                // Prioriza movimiento horizontal
                animDirection = new Vector2(finalInput.x, 0);
            }

            lastMoveDirection = animDirection;
        }

        animator.SetFloat("Horizontal", animDirection.x);
        animator.SetFloat("Vertical", animDirection.y);
        animator.SetBool("IsMoving", finalInput != Vector2.zero);
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
