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
            SceneController sceneController = FindFirstObjectByType<SceneController>();
            if (playerInventory != null)
            {
                playerInventory.CollectCoin(coinValue);
                if (sceneController != null)
                {
                    sceneController.LevelLayout(); // Update the coin count display
                }

            }

            // Destroy the coin after collection
            Destroy(gameObject);
        }
    }
    
}
