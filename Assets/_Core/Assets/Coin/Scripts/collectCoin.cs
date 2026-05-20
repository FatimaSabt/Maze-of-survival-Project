using UnityEngine;

public class collectCoin : MonoBehaviour
{
    public int coinValue = 1; // Value of the coin

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add coin value to player's inventory
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.CollectCoin(coinValue);
            }

            // Destroy the coin after collection
            Destroy(gameObject);
        }
    }
    
}
