using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [Header("Player Settings")]
    public GameObject player; // Drag Remy/player object here in the Inspector

    [Header("Damage Settings")]
    public int damageAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the object or its parent is the assigned player
        if (other.transform.root.gameObject == player)
        {
            // 2. Get the PlayerHealth script from the assigned player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            // 3. Damage the player if the health script exists
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}