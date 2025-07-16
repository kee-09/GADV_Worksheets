using UnityEngine;

// Class name should start with a capital letter
public class Impulse : MonoBehaviour
{
    public float moveSpeed = 5f;   // How fast the player moves
    public float jumpForce = 7f;   // How strong the jump is

    private Rigidbody rb;          // Stores the Rigidbody component
    private bool isGrounded;       // True if the player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody attached to this object
    }

    void Update()
    {
        // If Space is pressed and player is on the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Jump up
            isGrounded = false; // Player is now in the air
        }
    }

    void FixedUpdate()
    {
        // Get input for left/right and forward/back
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Make a movement vector
        Vector3 move = new Vector3(h, 0f, v) * moveSpeed;

        // Set the Rigidbody's velocity (keep current y velocity)
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        // If we hit something mostly below us, we are on the ground
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}