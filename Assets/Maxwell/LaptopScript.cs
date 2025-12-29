using UnityEngine;

public class LaptopScript : MonoBehaviour
{

    [SerializeField] GameObject LaptopUI;

    [SerializeField] float OpeningTime;

    [SerializeField] bool isOpen;

    Vector3 OpenPosition = new Vector3(530,200,0);

    Vector3 ClosePosition = new Vector3(530,-300,0);

    Vector3 GoalPosition;

    float SlideProgress = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, GoalPosition, SlideProgress/OpeningTime);
        if(SlideProgress < OpeningTime) SlideProgress += Time.deltaTime;
    }

    public void ToggleLaptop()
    {
        if (isOpen)
        {
            isOpen = false;
            GoalPosition = ClosePosition;
            SlideProgress = 0;
        }
        else
        {
            isOpen = true;
            GoalPosition = OpenPosition;
            SlideProgress = 0;
        }
    }

}
