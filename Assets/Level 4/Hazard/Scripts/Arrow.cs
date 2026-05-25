using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 1;

  AudioManager audioManager;

    void Awake()
    {
        Destroy(gameObject, 3f);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
                Debug.Log("Player hit by arrow! Damage: " + damage);
            }
        }else if (!collision.gameObject.CompareTag("Arrow_Shooter") && !collision.gameObject.CompareTag("Arrow"))
        {
            audioManager.PlaySFX(audioManager._arrowTrap);
            Destroy(gameObject);
            Debug.Log("Arrow collided with: " + collision.gameObject.name);
        }

    }
}