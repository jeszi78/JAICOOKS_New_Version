using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner2 : MonoBehaviour
{
    public GameObject customerPreFab;
    public Transform[] waitingSpots;

    public List<Order> possibleOrders;

    private int currentIndex = 0;
    public DeliveryCounter deliveryCounter;
    private Queue<Customer2> customerQueue = new Queue<Customer2>();


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCustomer), 2f, 5f);
    }




    void SpawnCustomr()
    {
        if (currentIndex >= waitingSpots.Length)
            return;

        GameObject customerObj = Instantiate(customerPrefab, waitingSpots[currentIndex].position, Quaternion.identity);

        Customer2 customer = customerObj.GetComponent<Customer2>();

        Order randomOrder = possibleOrders[Random.Range(0, possibleOrders.Count)];
        customer.SetOrder(randomOrder);


        customerQueue.Enqueue(customer);


        if(customerQueue.Count == 1)
        {
            deliveryCounter.SetCustomer(customer);

        }

        currentIndex++;

    }


    public void CustomerServed()
    {
        if (customerQueue.Count == 0)
            return;

        customerQueue.Dequeue();
        currentIndex--;

        int i = 0;
        foreach(Customer2 c in customerQueue)
        {
            c.transform.position = waitingSpots[i].position;
            i++;
        }

        if(customerQueue.Count > 0)
        {
            deliveryCounter.SetCustomer(customerQueue.Peek());
        }

    }




}
