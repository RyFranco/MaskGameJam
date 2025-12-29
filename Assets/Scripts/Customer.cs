using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;


public class Customer : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool hasTarget = false;

    public bool frontOfLine = false;

    [Header("Mask Variables")]           
    public SpriteRenderer Mask; 
    public Vector3 facingLeftPosition;
    public Vector3 facingRightPosition;



    public void MoveTo(Vector3 newPos)
    {
        targetPosition = newPos;
        hasTarget = true;
        if(newPos.x <= transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            Mask.flipX = true;
            Mask.gameObject.transform.localPosition = facingLeftPosition;
            
        }   
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Mask.flipX = false;
            Mask.gameObject.transform.localPosition = facingRightPosition;
        }
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
        Mask.sprite = ResourceManager.Instance.MaskSpritesForSale[Random.Range(0,ResourceManager.Instance.MaskSpritesForSale.Count)];

        GetComponent<SpriteRenderer>().GetComponent<SpriteRenderer>().sortingOrder = 2;
        Mask.sortingOrder = 3;


        await Task.Delay(6000);
        if (this != null && gameObject !=null)
        {
            Destroy(gameObject);
        }
    }

    

}
