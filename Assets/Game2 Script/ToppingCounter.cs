using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingCounter : BaseCounter2
{
    public string toppingName;

    public override void Interact(InteractionScript2 player)
    {
        if (player.HasFood())
        {
            GameObject heldFood = player.GetHeldFood();

            FoodObject2 food = heldFood.GetComponent<FoodObject2>();

            if (food != null)
            {
                food.AddTopping(toppingName);
            }
        }
    }
}
