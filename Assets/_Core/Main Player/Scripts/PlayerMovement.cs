using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Player walking speed
    public float rotationSpeed = 120f; // Player turning speed

    private Rigidbody rb;

    private float moveInput;
    private float turnInput;

    void Start()
    {
        // Get the Rigidbody component from the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get keyboard input
        moveInput = Input.GetAxis("Vertical");    
        turnInput = Input.GetAxis("Horizontal");   
    }

    void FixedUpdate()
    {
        // Move the player forward and backward using Rigidbody
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);

        // Rotate the player left and right
        Quaternion turnRotation = Quaternion.Euler(0f, turnInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}