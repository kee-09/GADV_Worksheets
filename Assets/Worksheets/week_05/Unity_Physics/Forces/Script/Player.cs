using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    // Reference to the CharacterController component
    private CharacterController controller;

    // Variables for player movement and actions
    [SerializeField] private float speed = 6.0f;         // Movement speed
    [SerializeField] private float radius = 6.0f;        // Explosion radius
    [SerializeField] private float power = 100.0f;       // Explosion force
    [SerializeField] private float kickStrength = 10.0f; // Kick force

    void Start()
    {
        // Get the CharacterController component
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("CharacterController not found on Player!");
        }
        else
        {
            controller.detectCollisions = false; // Optional: disable collisions
        }
    }

    void Update()
    {
        // Press K to kick
        if (Input.GetKeyDown(KeyCode.K))
        {
            Kick();
        }
        // Press E to trigger explosion
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckExplosion();
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    // Kicks nearby objects forward
    void Kick()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * kickStrength, ForceMode.Impulse);
            }
        }
    }

    // Draws a red wire sphere in the editor to show the radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Moves the player using input
    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        if (controller != null)
        {
            controller.SimpleMove(move * speed);
        }
    }

    // Applies an explosion force to nearby objects
    void CheckExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius, 1.0f, ForceMode.Impulse);
            }
        }
    }
}