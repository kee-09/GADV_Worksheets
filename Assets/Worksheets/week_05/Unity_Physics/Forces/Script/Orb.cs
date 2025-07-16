using UnityEngine;

public class Orb : MonoBehaviour
{
    public float impulseStrength = 10f; // How strong the push is

    private Rigidbody rb; // This will store the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody attached to this object
        rb.useGravity = false; // Turn off gravity so the orb doesn't fall
    }

    void Update()
    {
        // If the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Push the orb forward
            rb.AddForce(transform.forward * impulseStrength, ForceMode.Impulse);
        }
    }
}