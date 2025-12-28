using UnityEngine;

public class Masker : MonoBehaviour
{
    [Header("Masker Stats")]
    [SerializeField] float MaskYield = 1; //How many mask you get when it finishes craft
    [SerializeField] float CraftingTime = 10; //seconds to craft 
    [SerializeField] float CraftingProgress;

    
    [Header("RotationStats")]
    [SerializeField] GameObject Cradle;
    [SerializeField] GameObject Box;
    [SerializeField] float transformRange;
    [SerializeField] float weirdSpeed;
    Vector3 TargetScale;
    Vector3 OldScale;
    Vector3 RotateDirection;
    float RotationProgress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        InvokeRepeating("NewTransform",0f, Random.Range(0.5f,2f)/weirdSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        DoWeirdRotation();
        CraftMask();
    }


    void CraftMask()
    {
        CraftingProgress += Time.deltaTime;
        if(CraftingProgress >= CraftingTime)
        {
            FinishCraftingMask();
            CraftingProgress = 0;
        }
    }

    void FinishCraftingMask()
    {
        ResourceManager.Instance.editMuxsAndReturn((int)MaskYield);
        Debug.Log(name + " made "+ MaskYield +" Mask(s)");
    }

    void DoWeirdRotation()
    {
        Cradle.transform.localScale = Vector3.Lerp(OldScale,TargetScale,RotationProgress);
        Box.transform.Rotate(RotateDirection * weirdSpeed * Time.deltaTime);
        RotationProgress += Time.deltaTime;
    }
    
    void NewTransform()
    {
        RotateDirection = new Vector3(Random.Range(-360f,360f),Random.Range(-360f,360f),Random.Range(-360f,360f));
        OldScale = Cradle.transform.localScale;
        TargetScale = new Vector3(
            (transformRange + Random.Range(-1f,1f)) * 05, 
            (transformRange + Random.Range(-1f,1f)) * 10,
            (transformRange + Random.Range(-1f,1f)) * 20
            );
        RotationProgress = 0;

    }

}
