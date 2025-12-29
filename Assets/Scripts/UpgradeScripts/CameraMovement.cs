using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 mainCamera = new Vector3(0, 1, -10);
    Vector3 upgradeCamera = new Vector3(-14, 1, -10);
    bool isMovingCamera = false;
    Vector3 target;
    
    public void portalButtonPress()
    {
        if (transform.position == mainCamera)
        {
            target = upgradeCamera;
        }
        else
        {
            target = mainCamera;
        }
        isMovingCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovingCamera)
        {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, target, 30f * Time.deltaTime);


        if (Vector3.Distance(transform.position, target) < 0.01)
        {
            isMovingCamera = false;
        }

    }
}
