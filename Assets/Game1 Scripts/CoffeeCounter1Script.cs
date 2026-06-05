using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCounter1Script : BaseCounter1
{
    public GameObject foodPrefab;

    public override void Interact(InteractionScript1 player)
    {
        if (!player.HasFood())
        {
            GameObject food = Instantiate(foodPrefab);
            player.SetHeldFood(food);
        }
    }
    

}