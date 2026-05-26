using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Player Settings")]
    public GameObject target; // Drag Remy/player here

    [Header("AI Settings")]
    public float catchDistance = 1.5f; // Distance needed to damage player
    public float maxChaseDistance = 20f; // AI stops chasing if player is farther than this
    public int damageAmount = 1; // Damage caused by AI

    private Vector3 originalPosition; // AI starting position
    private Quaternion originalRotation; // AI starting rotation

    private bool isChasing = false;
    private bool hasDamagedPlayer = false;

    void Start()
    {
        // 1. Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // 2. Save the AI's original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // 1. Stop if Remy is not assigned
        if (target == null)
        {
            return;
        }

        // 2. Only chase after the trigger activates the AI
        if (isChasing == true)
        {
            // 3. Check distance between AI and Remy
            float distance = Vector3.Distance(transform.position, target.transform.position);

            // 4. Stop chasing if Remy is too far away
            if (distance > maxChaseDistance)
            {
                StopChasing();
                return;
            }

            // 5. Follow Remy using NavMesh pathfinding
            agent.SetDestination(target.transform.position);

            // 6. Damage Remy if close enough
            if (distance <= catchDistance && hasDamagedPlayer == false)
            {
                DamagePlayer();
            }
        }
    }

    void DamagePlayer()
    {
        // 1. Get PlayerHealth from Remy
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

        // 2. Damage Remy if the script exists
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }

        // 3. Prevent repeated instant damage
        hasDamagedPlayer = true;
    }

    void StopChasing()
    {
        // 1. Stop chasing the player
        isChasing = false;

        // 2. Stop the AI movement
        agent.ResetPath();

        // 3. Allow damage again next time chase starts
        hasDamagedPlayer = false;

        // Optional: send AI back to its starting position
        agent.SetDestination(originalPosition);
    }

    public void ActivateChase()
    {
        // 1. Start chasing Remy
        isChasing = true;

        // 2. Allow AI to damage Remy again
        hasDamagedPlayer = false;
    }
}