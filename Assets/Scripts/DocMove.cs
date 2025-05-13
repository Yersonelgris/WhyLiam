using UnityEngine;

public class DocMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D docRb; 
    private Animator docAnim;
        void Start()
    {
        docRb = GetComponent<Rigidbody2D>();
        docAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        docAnim.SetFloat("Horizontal",moveX);
        docAnim.SetFloat("Vertical",moveY);
        docAnim.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    void FixedUpdate()
    {
        docRb.MovePosition(docRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
