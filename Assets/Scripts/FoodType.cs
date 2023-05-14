using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfFood
{
    banana, fish, meat
}
public class FoodType : MonoBehaviour
{

    public TypeOfFood typeOfFood;

    // Update is called once per frame
    void Update()
    {

    }

    public void Consume()
    {
        gameObject.SetActive(false);
    }
}
