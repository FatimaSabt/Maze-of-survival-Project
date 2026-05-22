using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Ground Verification")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

     private Vector3 velocity;
    private bool isGrounded;

    [Header("Footstep Settings")]
    public float footstepInterval = 0.45f;
    private float footstepTimer;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // 1. Ground Check Logic
        // Creates an invisible physics sphere at the groundCheck point.
        // It returns true if it overlaps with any object set to your groundMask layer.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Prevents exponential gravity accumulation when standing safely on a surface
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        // 2. Gather Input
        // Read keyboard inputs (W/S/A/D or Arrow keys)
        float x = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float z = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        // 3. Directional Calculation
        // Calculates directional velocity relative to the player's orientation.
        // (Right now it moves globally; later it will follow the camera's gaze).
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply horizontal movement 
        controller.Move(move * speed * Time.deltaTime);

        // 4. Jump Handling (Spacebar)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Physics formula to calculate required upward velocity for a target height
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            audioManager.PlaySFX(audioManager._playerJump);
        }

        // 5. Gravity System
        // Updates downwards velocity over time and pushes the character controller downward
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // 6. Footstep Sound Logic
        // Plays footstep sounds when the player is moving on the ground.
         HandleFootstepAudio(move);
    }

    private void HandleFootstepAudio(Vector3 move)
    {
        if (audioManager == null)
        {
            return;
        }

        if (isGrounded && move.magnitude > 0.1f)
        {
            // Decrease the timer based on elapsed time
            footstepTimer -= Time.deltaTime;

            // When the timer reaches zero, play a footstep sound and reset the timer
            if (footstepTimer <= 0f)
            {
                audioManager.PlaySFX(audioManager._playerFootsteps);
                // Reset the timer to the defined interval for the next footstep sound
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }


}

