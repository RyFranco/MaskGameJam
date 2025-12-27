using UnityEngine;
using System.Collections;
public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private Line line;
    [SerializeField] private GameObject customer;
    [SerializeField] private Transform spawnNode;
    [SerializeField] private float Demand = 1f;

    private Coroutine spawnRoutine;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    public void SpawnCustomer()
    {
        if (line.amountOfCustomerInLine < 6)
        {
            GameObject newCustomer = Instantiate(customer, spawnNode.position, Quaternion.identity);
            line.AddCustomer(newCustomer.GetComponent<Customer>());          
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnCustomer();
            yield return new WaitForSeconds(10 / Demand);
            Demand++;
        }
    }





}
