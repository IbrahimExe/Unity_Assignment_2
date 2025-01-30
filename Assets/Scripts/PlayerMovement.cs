using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; // Reference to the rigidbody of the player
    [SerializeField] float speed;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private Animator animator;

    [SerializeField] private KeyCode rightKeyCode = KeyCode.D;
    [SerializeField] private KeyCode leftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode jumpKeyCode = KeyCode.W;

    private bool canJump = true;

    float horizontalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        animator.SetFloat("Direction", 1.0f);
    }

    void Update() // INPUTS GO HERE - Makes them more responsive
    {
        if (Input.GetKeyDown(jumpKeyCode) && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            canJump = false;

            animator.SetBool("IsJumping", true);
        }

        horizontalMovement = 0.0f;
        if (Input.GetKey(rightKeyCode))
        {
            horizontalMovement += 1.0f;
        }
        if (Input.GetKey(leftKeyCode))
        {
            horizontalMovement -= 1.0f;
        }
        horizontalMovement = horizontalMovement * speed;

        if (horizontalMovement < 0)
        {
            animator.SetFloat("Direction", -1.0f);
        }
        else if (horizontalMovement > 0)
        {
            animator.SetFloat("Direction", 1.0f);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        animator.SetBool("IsFalling", rb.linearVelocityY < -0.2f);
    }

    private void FixedUpdate() // PHYSICS GO HERE - So movement is not tied to FPS
    {
        rb.linearVelocity = new Vector2(horizontalMovement, rb.linearVelocityY);
    }

    public void LandedOnGround()
    {
        canJump = true;

        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }
}
