using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript2 : MonoBehaviour
{
    public Transform holdPoint;
    public float interactDistance = 2f;
    public LayerMask counterLayer;

    private GameObject heldFood;

    public GameObject GameManager;

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
            transform.forward,
            (transform.forward + transform.right).normalized,
            transform.right,
            (-transform.forward + transform.right).normalized,
            -transform.right,
            (-transform.forward - transform.right).normalized,
            -transform.right,
            (transform.forward - transform.right).normalized
        };


        BaseCounter2 closestCounter = null;

        foreach (Vector3 dir in directions)
        {
            Ray ray = new Ray(transform.position, dir);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance, counterLayer))
            {
                BaseCounter2 currentCounter = hit.collider.GetComponent<BaseCounter2>();

                if (closestCounter == null)
                {
                    closestCounter = currentCounter;
                }
                else if (currentCounter != null && closestCounter != null)
                {
                    if (Vector3.Distance(transform.position, currentCounter.transform.position)
                        < Vector3.Distance(transform.position, closestCounter.transform.position))
                    {
                        closestCounter = currentCounter;
                    }
                }


            }

            Debug.DrawRay(transform.position, dir * interactDistance, Color.red, 1f);


        }

        if (closestCounter != null)
        {
            closestCounter.Interact(this);
        }


    }


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

        if (HasFood())
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