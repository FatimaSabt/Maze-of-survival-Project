using UnityEngine;

public class collectCoin : MonoBehaviour
{
    public int coinValue = 1; // Value of the coin

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager._coinCollect);
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
