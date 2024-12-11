using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTimer : MonoBehaviour
{
    private List<string> orderList = new List<string>();

    private float addOrderTimer = 0f;
    private float removeOrderTimer = 0f;
    private int orderCount = 1;
    private int orderNumber = 1;

    void Update()
    {
        addOrderTimer += Time.deltaTime;
        removeOrderTimer += Time.deltaTime;

        if (addOrderTimer >= 2f)
        {
            if (orderCount <= 5)
            {
                string newOrder = "Order " + orderNumber++;
                orderCount++;
                orderList.Add(newOrder);

                Debug.Log("Current Orders: " + string.Join(", ", orderList));
            }

            addOrderTimer = 0f;
        }

        if (removeOrderTimer >= 20f)
        {
            RemoveOrder();
            removeOrderTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RemoveOrder();
        }
    }

    private void RemoveOrder()
    {
        if (orderList.Count > 0)
        {
            orderList.RemoveAt(0);
            orderCount--;
            Debug.Log("Current Orders: " + string.Join(", ", orderList));
        }
        else
        {
            Debug.Log("No orders to remove.");
        }
    }
}
