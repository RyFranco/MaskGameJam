using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;


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

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2f * Time.deltaTime);


        if(Vector3.Distance(transform.position, targetPosition) < 0.05)
        {
            transform.position = targetPosition;
            hasTarget = false;
        }
    }

    public async void LeaveStore()
    {
        MoveTo(new Vector3(8.46f,-2.36f,0));
        GetComponent<SpriteRenderer>().flipX = false;
        await Task.Delay(6000);
        if (this != null && gameObject !=null)
        {
            Destroy(gameObject);
        }
    }

    

}
