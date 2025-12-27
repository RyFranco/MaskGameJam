using UnityEngine;
using System.Collections.Generic;

public class Customer : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool hasTarget = false;


    public void MoveTo(Vector3 newPos)
    {
        targetPosition = newPos;
        hasTarget = true;
    }

    void Update()
    {
        if(!hasTarget) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.5f * Time.deltaTime);


        if(Vector3.Distance(transform.position, targetPosition) < 0.05)
        {
            transform.position = targetPosition;
            hasTarget = false;
        }
    }

    

}
