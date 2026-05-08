using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer2 : MonoBehaviour
{

    public Order order;


    public void SetOrder(Order newOrder)
    {
        order = newOrder;
        Debug.Log("Customer wants: " + order.foodName);
    }

    public bool CheckOrder(FoodObject2 food)
    {
        foreach (string topping in order.requiredToppings)
        {
            if (!food.toppings.Contains(topping))
                return false;
        }

        return true;
    }



}
