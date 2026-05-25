using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object touching the spikes is the player
        if (other.CompareTag("Remy"))
        {
            // Get the PlayerHealth script from the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // If the player has the health script, damage the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}