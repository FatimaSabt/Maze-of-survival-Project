using UnityEngine;
public class BladeDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;
    public float damageInterval = 0.5f;

    [Header("Effects")]
    public GameObject bloodEffect;
    public float knockbackForce = 8f;

    private float damageTimer;
    private Collider bladeCollider;
    private AudioManager audioManager;

    void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        audioManager = GameObject.FindGameObjectWithTag("Audio")
                                  .GetComponent<AudioManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        damageTimer -= Time.deltaTime;
        if (damageTimer > 0f)
            return;

        PlayerHealth player = other.GetComponent<PlayerHealth>();
        Rigidbody playerRb = other.GetComponent<Rigidbody>();

        if (player == null)
            return;

        // DAMAGE
        player.TakeDamage(damage);
        damageTimer = damageInterval;

        // BLOOD
        Vector3 hitPoint = bladeCollider.ClosestPoint(other.transform.position);
        if (bloodEffect != null)
        {
            Instantiate(bloodEffect, hitPoint, Quaternion.identity);
        }

        /*/ SOUND
        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager._bladeTrap);
        }*/

        // KNOCKBACK
        if (playerRb != null)
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            direction.y = 0.3f;
            playerRb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }
    }
}