using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; // Reference to the rigidbody of the player
    [SerializeField] float speed;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private SpriteRenderer sprite;

    private bool canJump = true;

    float horizontalMovement;

    void Start()
    {
        
    }

    void Update() // INPUTS GO HERE - Makes them more responsive
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            canJump = false;
        }

        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (horizontalMovement < 0)
        {
            sprite.flipX = true;
        }
        else if (horizontalMovement > 0)
        {
            sprite.flipX = false;
        }
    }

    private void FixedUpdate() // PHYSICS GO HERE - So movement is not tied to FPS
    {
        rb.linearVelocity = new Vector2(horizontalMovement, rb.linearVelocityY);
    }

    public void LandedOnGround()
    {
        canJump = true;
    }
}
