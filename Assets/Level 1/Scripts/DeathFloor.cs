using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{
    [Header("Settings")]
    public string playerTag = "Player";         // Tag your player GameObject with "Player"
    public bool reloadSceneOnDeath = false;     // Set true to restart the scene on death
    public string deathSceneName = "";          // Optional: load a specific scene on death


    public AudioSource audioSource;

    AudioManager audioManager;
     void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (audioManager != null)
        {
           
            audioSource.enabled = audioManager.isSoundOn;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player entered death floor!");
            KillPlayer(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Player collided with death floor!");
            KillPlayer(collision.gameObject);
        }
    }

    private void KillPlayer(GameObject player)
    {
        // --- Option 1: Kill via a Health component ---
        // If your player has a Health or PlayerHealth script, call it here.
        // Example:
        //   PlayerHealth health = player.GetComponent<PlayerHealth>();
        //   if (health != null) { health.Die(); return; }

        // --- Option 2: Reload the current scene ---
        if (reloadSceneOnDeath)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        // --- Option 3: Load a specific scene (e.g. a Game Over screen) ---
        if (!string.IsNullOrEmpty(deathSceneName))
        {
            SceneManager.LoadScene(deathSceneName);
            return;
        }

        // --- Default: Destroy the player GameObject immediately ---
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1); // Inflict enough damage to ensure death
        }

    }
}
