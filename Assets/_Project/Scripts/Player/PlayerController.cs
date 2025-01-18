using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 4.5f;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    private PlayerInteractor interactor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        interactor = GetComponent<PlayerInteractor>();
    }

    private void Update()
    {
        HandleMove();
        HandleJump();

        if(Input.GetKeyDown(KeyCode.F))
        {
            interactor.TryInteract();
        }
    }

    private void HandleMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveSpeed * horizontalInput, rb.linearVelocity.y);
    }

    private void HandleJump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Floor Tag와 충돌 시 isGrounded를 참으로.
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
