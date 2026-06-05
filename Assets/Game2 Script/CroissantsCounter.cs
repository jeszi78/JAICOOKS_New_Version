using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroissantsCounter : BaseCounter2
{
public GameObject foodPrefab;
   
 public override void Interact(InteractionScript2 player)
    {
        if (!player.HasFood())
        {
            GameObject food = Instantiate(foodPrefab);
            player.SetHeldFood(food);
        }
    }
}
