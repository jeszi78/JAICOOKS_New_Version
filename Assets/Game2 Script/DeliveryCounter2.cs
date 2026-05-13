using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter2 : BaseCounter2
{
    private Customer2 currentCustomer;
    public CustomerSpawner2 spawner;
    public AudioSource audio;

    public void SetCustomer(Customer2 customer)
    {
        currentCustomer = customer;
        if (currentCustomer != null)
        {
            Debug.Log("Now serving:" + currentCustomer.order.foodName);
        }
    }

    public override void Interact (InteractionScript2 player)
    {
           if (!player.HasFood() || currentCustomer == null)
          return;




        GameObject heldFoodObj = player.GetHeldFood();
        FoodObject2 food = heldFoodObj.GetComponent<FoodObject2>();


        if (food == null)
            return;


        if(currentCustomer.CheckOrder(food))
        {

            Debug.Log("Correct Order!");
            Destroy(currentCustomer.gameObject);
            Destroy(heldFoodObj);
            player.ClearHeldFood();
            spawner.CustomerServed();

        }
        else
        {
            Debug.Log("Wrong Order!");


            audio.Play();
        }





    }


   
}
