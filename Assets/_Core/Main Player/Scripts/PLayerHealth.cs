using UnityEngine;

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
        Destroy(gameObject);

        // ----- New Code ------

        // try this later
        // // Disable player movement so they freeze in place
        // GetComponent<PlayerMovement>().enabled = false;
        
        // Trigger the Global Lose UI
        UIManager.Instance.ShowLoseScreen();
    }
}