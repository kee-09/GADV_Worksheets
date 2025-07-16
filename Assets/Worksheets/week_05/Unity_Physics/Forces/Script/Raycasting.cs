using UnityEngine;

public class RayCasting : MonoBehaviour
{
    void Start()
    {
        CheckLineOfSight(); // Run the check once when the game starts
    }

    void CheckLineOfSight()
    {
        // Find all objects with the "Enemy01" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy01");
        RaycastHit hit; // Stores info about what the ray hits

        foreach (GameObject Enemy01 in enemies)
        {
            // Get the direction from this object to the enemy
            Vector3 direction = Enemy01.transform.position - transform.position;

            // Draw a red line in the Scene view for visualization
            Debug.DrawRay(transform.position, direction, Color.red, 1f);

            // Shoot a ray towards the enemy, up to 30 units away
            if (Physics.Raycast(transform.position, direction, out hit, 30f))
            {
                // If the ray hits the enemy directly
                if (hit.collider.gameObject == Enemy01)
                {
                    // Change the enemy's color to green (visible)
                    Enemy01.GetComponent<Renderer>().material.color = Color.green;
                }
                else
                {
                    // Change the enemy's color to red (blocked)
                    Enemy01.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }
}