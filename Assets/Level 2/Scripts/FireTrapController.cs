using UnityEngine;
using System.Collections;

public class FireTrapController : MonoBehaviour
{
    [Header("Visuals & Physics")]
    public ParticleSystem fireParticles;
    public ParticleSystem warningSmoke;
    public Collider damageCollider;

    [Header("Trap Timings")]
    public float idleTime = 2.0f;
    public float warningTime = 1.0f;
    public float fireTime = 2.0f;

    void Start()
    {
        // fireParticles.gameObject.SetActive(false);
        // warningSmoke.gameObject.SetActive(false);
        // Start the trap cycle immediately
        StartCoroutine(TrapCycle());
    }

    IEnumerator TrapCycle()
    {
        while (true)
        {
            // Safety Check 1: If the objects are destroyed, exit the loop immediately
            if (fireParticles == null || warningSmoke == null || damageCollider == null)
            {
                yield break;
            }

            // State 1: Idle (Everything is off)
            fireParticles.Stop();
            warningSmoke.Stop();
            damageCollider.enabled = false;
            yield return new WaitForSeconds(idleTime);

            // Safety Check 2: Check again after waiting
            if (warningSmoke == null) yield break;

            // State 2: Telegraph Warning (Smoke only)
            warningSmoke.Play();
            yield return new WaitForSeconds(warningTime);

            // Safety Check 3: Check one last time before the lethal state
            if (fireParticles == null || warningSmoke == null || damageCollider == null) yield break;

            // State 3: Active Hazard (Fire and Collider ON)
            warningSmoke.Stop();
            fireParticles.Play();
            damageCollider.enabled = true;
            yield return new WaitForSeconds(fireTime);
        }
    }

    // IEnumerator TrapCycle()
    // {
    //     while (true)
    //     {
    //         // -------------------------
    //         // IDLE
    //         // -------------------------
    //         fireParticles.gameObject.SetActive(false);
    //         warningSmoke.gameObject.SetActive(false);

    //         damageCollider.enabled = false;

    //         yield return new WaitForSeconds(idleTime);

    //         // -------------------------
    //         // WARNING
    //         // -------------------------
    //         warningSmoke.gameObject.SetActive(true);

    //         yield return new WaitForSeconds(warningTime);

    //         // -------------------------
    //         // FIRE ACTIVE
    //         // -------------------------
    //         warningSmoke.gameObject.SetActive(false);

    //         fireParticles.gameObject.SetActive(true);

    //         damageCollider.enabled = true;

    //         yield return new WaitForSeconds(fireTime);
    //     }
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Insert your game over or damage logic here
            Debug.Log("Player stepped in the fire!");
        }
    }
}