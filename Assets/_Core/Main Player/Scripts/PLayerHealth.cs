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
    }
}