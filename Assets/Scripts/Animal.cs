using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // detect player
    private GameObject target;
    [SerializeField]
    float visionRange = 30.0f;
    [SerializeField]
    float speed = 1.0f;

    // Food
    [SerializeField]
    TypeOfFood foodItLikes;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget(target);
    }


    // if player enters radius of vision, go to them
    // need extra collider

    void MoveTowardsTarget(GameObject target)
    {
        // get both positions
        float distance = Vector3.Distance(transform.position, target.transform.position);
        // lerp them
        if (distance <= visionRange)
        {
            transform.LookAt(target.transform.position);
            // make animal move
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("Game over!");
        }

        if (other.gameObject.CompareTag("Food"))
        {
            TypeOfFood tof = other.gameObject.GetComponent<FoodType>().typeOfFood;
            if (tof == foodItLikes)
            {
                gameObject.SetActive(false);
                other.gameObject.SetActive(false);
                Debug.Log("Animal fed!");
            }
            else
            {
                // if wrong food, animal gets faster
                other.gameObject.SetActive(false);
                speed += 1.0f;
                Debug.Log("Dont like this food!");
            }
        }
    }

    // if animal collides with food correct, then disable
}
