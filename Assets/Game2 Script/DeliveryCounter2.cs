using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryCounter2 : BaseCounter2
{
    private Customer2 currentCustomer;
    public CustomerSpawner2 spawner;
    public AudioSource audio;

    public TextMeshProUGUI ordertext;
    public GameObject GameManager;
    public GameObject gameManagerObject;
    

    public void SetCustomer(Customer2 customer)
    {
        currentCustomer = customer;
        
        if (currentCustomer != null)
        {
            string toppingsText = string.Join(", ", currentCustomer.order.requiredToppings);
            Debug.Log("Now serving:" + currentCustomer.order.foodName);


            ordertext.text = "Now Serving: \n " + currentCustomer.order.foodName + " with " + toppingsText;
            StartCoroutine(customertimer());
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
            StopAllCoroutines();
            Debug.Log("Correct Order!");
            Destroy(currentCustomer.gameObject);
            Destroy(heldFoodObj);
            player.ClearHeldFood();
            spawner.CustomerServed();
            GameManager.GetComponent<GM>().score += 20;




        }
        else
        {
            Debug.Log("Wrong Order!");
            Destroy(heldFoodObj);
            GameManager.GetComponent<GM>().score -= 20;


            audio.Play();
        }







    }



    public IEnumerator customertimer()
    {
        yield return new WaitForSeconds(30f);
        Debug.Log("customer left");
        Destroy(currentCustomer.gameObject);
        spawner.CustomerServed();
    }


    




}
