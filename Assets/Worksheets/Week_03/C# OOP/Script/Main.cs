using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public class Projectile
    {
        // Private float variable to store the speed of the projectile
        private float speed;

        // Constructor that takes a float parameter and assigns it to speed
        public Projectile(float initialSpeed)
        {
            speed = initialSpeed;
        }

        // Public method that prints the current speed of the projectile
        public void Fire()
        {
            // In Unity, Debug.Log is used to print messages to the console
            Debug.Log($"Firing projectile at speed {speed}");
        }
    }

    public class Player
    {
        private int health;

        public Player(int startingHealth)
        {
            health = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health < 0)
            {
                health = 0;
            }
        }

        public int GetHealth()
        {
            return health;
        }
    }



    void Start()
    {
       

        // Create a new instance of the Projectile class, with speed set to 50
        Projectile projectile = new Projectile(50f);

        // Call the Fire() method to simulate firing the projectile
        projectile.Fire();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
