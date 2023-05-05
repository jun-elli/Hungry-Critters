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

    // Grab food
    public GameObject hands;
    private SphereCollider handsCollider;
    private GameObject food;
    public Transform grabbedFoodPosition;
    [SerializeField]
    bool hasFood;
    [SerializeField]
    bool isFoodAround;

    private void Start()
    {
        handsCollider = hands.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GrabFood();
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

    void GrabFood()
    {
        // if we have food, collider should be inactive
        // if we don't have food collider should be active

        if (!hasFood && isFoodAround && Input.GetKeyDown(KeyCode.F))
        {
            // make food part of player
            food.transform.parent = transform;
            food.transform.position = grabbedFoodPosition.position;
            food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            hasFood = true;
        }
        else if (hasFood && Input.GetKeyDown(KeyCode.F))
        {
            // make food fall away
            food.transform.parent = null;
            food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            hasFood = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            isFoodAround = true;
            food = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            isFoodAround = false;
            food = null;
        }
    }

}
