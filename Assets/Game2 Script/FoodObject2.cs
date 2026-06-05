using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject2 : MonoBehaviour
{
    public List<string> toppings = new List<string>();


    public void AddTopping(string toppingName)
    {
        if (!toppings.Contains(toppingName))
        {
            toppings.Add(toppingName);
            Debug.Log("Added topping: " + toppingName);
        }
    }
}
