using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed;

    public LayerMask groundMask;

    public Rigidbody rb;

    public bool itemHeld;
    public GameObject currentItem;
    public Transform cameraPosition;
    public LayerMask interactMask;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
        transform.Translate(speed * Time.deltaTime * moveDirection);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!itemHeld)
            {
                if (Physics.Raycast(cameraPosition.position, cameraPosition.forward, out RaycastHit reach, 1.5f, interactMask))
                {
                    itemHeld = true;
                    currentItem = reach.collider.gameObject;
                    currentItem.GetComponent<ItemController>().isHeld = true;
                    currentItem.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            else
            {
                itemHeld = false;
                currentItem.GetComponent<ItemController>().isHeld = false;
                currentItem.GetComponent<Rigidbody>().useGravity = true;
                currentItem = null;
            }
        }

    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position - new Vector3(0, .9f, 0), Vector3.down,
          out RaycastHit hit, .2f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
