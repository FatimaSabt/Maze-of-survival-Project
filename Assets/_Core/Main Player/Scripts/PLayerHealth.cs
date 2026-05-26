using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 1;

    public void TakeDamage(int amount)
    {
        lives -= amount;

        if (lives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        // Destroy(gameObject);

        // ----- New Code ------

        // Disable player movement so they freeze in place
        GetComponent<PlayerMovement>().enabled = false;

        PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        
        int currentCoins = inventory.coinCount;
        int maxCoins = SceneController.Instance.LvlCoins;
        float timeTaken = Time.timeSinceLevelLoad;
        string levelName = SceneManager.GetActiveScene().name;

        // Trigger the Global Lose UI
        UIManager.Instance.ShowLoseScreen(currentCoins, maxCoins, timeTaken, levelName);
    }
}