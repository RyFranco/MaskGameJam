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

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1.5f * Time.deltaTime);


        if(Vector3.Distance(transform.position, targetPosition) < 0.05)
        {
            transform.position = targetPosition;
            hasTarget = false;
        }
    }

    public async void LeaveStore()
    {
        MoveTo(new Vector3(0.780099988f,-0.289000005f,-0.0289999843f));
        GetComponent<SpriteRenderer>().flipX = false;
        await Task.Delay(2700);
        if (this != null && gameObject !=null)
        {
            Destroy(gameObject);
        }
    }

    

}
