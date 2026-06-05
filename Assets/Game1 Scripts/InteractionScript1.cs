using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript1 : MonoBehaviour
{
    public Transform holdPoint;
    public float InteractDistance = 2f;
    public LayerMask counterLayer;

    private GameObject heldFood; //This is where the food object will be strored

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
         Vector3[] directions =
        {
            transform.forward,(transform.forward + transform.right). normalized, transform.right, (-transform.forward + transform.right). normalized,(-transform.forward - transform.right).normalized, (transform.forward - transform.right).normalized
        };

        BaseCounter1 closestCounter = null;
        //foreach is like a for loop, but it goes throught an array/list on time per element in the collection
        foreach(Vector3 dir in directions)
        {
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;

           if(Physics.Raycast(ray, out hit, InteractDistance, counterLayer))
           {
               BaseCounter1 currentCounter = hit.collider.GetComponent<BaseCounter1>();
            
               if(closestCounter == null)
               {
                  closestCounter = currentCounter;
               }
              else if(currentCounter != null && closestCounter != null)
              {
                if(Vector3.Distance(transform.position, currentCounter.transform.position) < Vector3.Distance(transform.position, closestCounter.transform.position))
                {
                   closestCounter = currentCounter;
                }
              }
             
            }
            Debug.DrawRay(transform.position, dir * InteractDistance, Color. red, 1f);
        }

        if(closestCounter != null)
        {
            closestCounter.Interact(this);
        }
    }

    // ---------- FOOD HANDLING FUNCTIONS ----------

    public bool HasFood()
    {
        return heldFood != null;
    } 

    public GameObject GetHeldFood() 
    {
        return heldFood;
    }

    public void SetHeldFood(GameObject food)
    {
        heldFood = food;

        if(HasFood())
        {
            heldFood.transform.SetParent(holdPoint);
            heldFood.transform.localPosition = Vector3.zero;
            heldFood.transform.localRotation = Quaternion.identity;
        }
    }

    public void ClearHeldFood()
    {
        heldFood = null;
    }
   
}  



