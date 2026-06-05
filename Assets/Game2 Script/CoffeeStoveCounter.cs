using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeStoveCounter : BaseCounter2
{
    public GameObject cookedFoodPrefab;
    public float cookTime = 3f;

    private GameObject currentFood;
    private bool isCooking = false;

    public AudioSource audio;




    public override void Interact(InteractionScript2 player)
    {
        if(player.HasFood() && currentFood == null)
        {
            currentFood = player.GetHeldFood();

            player.ClearHeldFood();

            currentFood.transform.SetParent(transform);
            currentFood.transform.localPosition = Vector3.up;

            StartCoroutine(CookFood());
        }
        else if (!player.HasFood() && currentFood != null && !isCooking)
        {
            player.SetHeldFood(currentFood);
            currentFood = null;
        }
    }

    IEnumerator CookFood()
    {
        isCooking = true;

        yield return new WaitForSeconds(cookTime);

        Destroy(currentFood);

        currentFood = Instantiate(cookedFoodPrefab);
        currentFood.transform.SetParent(transform);
        currentFood.transform.localPosition = Vector3.up;

        audio.Play();

        isCooking = false;
    }
    
}
