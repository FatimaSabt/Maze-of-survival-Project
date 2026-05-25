using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_AI : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject target; // Drag the player here
    public float sightDistance = 15f; // How far the AI can see
    public float catchDistance = 1.5f; // Distance needed to catch player

    private Vector3 originalPosition; // AI starting position
    private Quaternion originalRotation; // AI starting rotation

    private bool isChasing = false; // AI only chases after player enters trigger area

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Save the AI's original spawn position
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Only run this if the AI has been activated
        if (isChasing == true)
        {
            // Check if the AI can still see the player
            if (CanSeePlayer())
            {
                // Follow the player
                agent.destination = target.transform.position;

                // Check if AI is close enough to catch the player
                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (distance <= catchDistance)
                {
                    PlayerCaught();
                }
            }
            else
            {
                // If player is out of sight, return AI to original place
                RespawnEnemy();
            }
        }
    }

    bool CanSeePlayer()
    {
        // Direction from AI to player
        Vector3 directionToPlayer = target.transform.position - transform.position;

        // Check distance first
        if (directionToPlayer.magnitude > sightDistance)
        {
            return false;
        }

        RaycastHit hit;

        // Cast a ray from AI toward the player
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, sightDistance))
        {
            // If the ray hits the player, AI can see them
            if (hit.collider.CompareTag("Remy"))
            {
                return true;
            }
        }

        return false;
    }

    void RespawnEnemy()
    {
        // Stop chasing
        isChasing = false;

        // Stop the NavMeshAgent before moving it manually
        agent.ResetPath();

        // Disable agent temporarily so we can teleport it
        agent.enabled = false;

        // Move AI back to original place
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Enable agent again
        agent.enabled = true;
    }

    void PlayerCaught()
    {
        // Restart the current scene when the player is caught
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider other)
    {
        // Start chasing when player enters the AI activation area
        if (other.CompareTag("Remy"))
        {
            isChasing = true;
        }
    }

    public void ActivateChase()
    {
        // Start chasing the player
        isChasing = true;
    }
}