using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Refs
    public CharacterController controller;
    public Transform groundSensor;
    public LayerMask groundMask;

    // Vars
    [SerializeField]
    private float speed = 5.0f;
    private float gravity = -9.8f;
    Vector3 velocity;
    private float groundDistance = 0.2f;
    bool isGrounded;
    float jumpHeight = 3f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // create a sphere to check if bumping into ground
        isGrounded = Physics.CheckSphere(groundSensor.position, groundDistance, groundMask);
        // if we're on the ground, and velocity is less than 0 (remember is negative)
        if (isGrounded && velocity.y < 0)
        {
            // reset velocity to saty on ground
            velocity.y = -2f;
        }

        // if input horizontal
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        // vector direction we wanna move
        Vector3 move = transform.right * x + transform.forward * z;
        // Move player in desired direction
        controller.Move(move * speed * Time.deltaTime);

        // enable jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Make player fall if not touching ground
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
