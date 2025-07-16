using UnityEngine;

public class Beam : MonoBehaviour
{
    public float torqueStrength = 100f; // How strong the spin is

    private Rigidbody rb; // Stores the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody attached to this object
    }

    void Update()
    {
        // If Z is pressed, spin the beam clockwise
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddTorque(Vector3.up * torqueStrength, ForceMode.Impulse);
        }

        // If X is pressed, spin the beam counter-clockwise
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddTorque(-Vector3.up * torqueStrength, ForceMode.Impulse);
        }
    }
}