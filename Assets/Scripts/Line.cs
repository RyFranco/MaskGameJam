using UnityEngine;
using System.Collections.Generic;

public class Line : MonoBehaviour
{
    public Transform[] lineNodes;
    private Queue<Customer> customersQueue = new Queue<Customer>();
    public int amountOfCustomerInLine;

    public void AddCustomer(Customer customer)
    {
        customersQueue.Enqueue(customer);
        amountOfCustomerInLine++;
        UpdateLinePosition();
    }

    public void RemoveFrontCustomer()
    {
        if(customersQueue.Count == 0) return; 

        customersQueue.Peek().MoveTo(new Vector3(0.780099988f,-0.289000005f,-0.0289999843f));
        customersQueue.Dequeue();
        amountOfCustomerInLine--;

        UpdateLinePosition();
    }

    public void UpdateLinePosition()
    {
        int temp = 0;

        foreach(Customer customer in customersQueue)
        {
            if(temp >= lineNodes.Length) break;

            customer.MoveTo(lineNodes[temp].position);
            temp++;
        }
    }
    
   






}
