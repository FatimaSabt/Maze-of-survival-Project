using UnityEngine;
using System.Collections;

public class FireTrapController : MonoBehaviour
{
    [Header("Visuals & Physics")]
    public ParticleSystem fireParticles;
    public ParticleSystem warningSmoke;
    public Collider damageCollider;


    [Header("Trap Timings")]
    public float idleTime = 4.0f;
    public float warningTime = 2.0f;
    public float fireTime = 3.0f;

    [Header("Audio sources")]
    public AudioSource steam;
    public AudioSource fire;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Start the trap cycle immediately
        StartCoroutine(TrapCycle());
    }

    IEnumerator TrapCycle()
    {
        while (true)
        {
            // Safety Check 1
            if (fireParticles == null || warningSmoke == null || damageCollider == null) yield break;

            // State 1: Idle (Everything is off, fully cleared)
            fireParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            warningSmoke.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            damageCollider.enabled = false;
            yield return new WaitForSeconds(idleTime);

            // Safety Check 2
            if (warningSmoke == null) yield break;

            // State 2: Telegraph Warning (Smoke only)
            warningSmoke.Play();

            if (audioManager != null && audioManager.isSoundOn)
            {
                steam.Play();
            }

            yield return new WaitForSeconds(warningTime);

            // Safety Check 3
            if (fireParticles == null || warningSmoke == null || damageCollider == null) yield break;

            // State 3: Active Hazard (Fire and Collider ON, clear smoke)
            warningSmoke.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            steam.Stop();

            fireParticles.Play();

            if (audioManager != null && audioManager.isSoundOn)
            {
                fire.Play();
            }

            damageCollider.enabled = true;
            yield return new WaitForSeconds(fireTime);

            fire.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null && damageCollider.enabled)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}