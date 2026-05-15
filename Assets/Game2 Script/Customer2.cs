using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer2 : MonoBehaviour
{

    public Order order;

    public float ordertimer;
    

    public void SetOrder(Order newOrder)
    {
        order = newOrder;

        string toppingsText = string.Join(", ", order.requiredToppings);

        Debug.Log("Customer wants: " + order.foodName + " with " + toppingsText);
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
