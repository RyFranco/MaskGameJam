using UnityEngine;
using System.Collections;
public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private Line line;
    [SerializeField] private GameObject[] customers;
    [SerializeField] private Transform spawnNode;

    private Coroutine spawnRoutine;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    public void SpawnCustomer()
    {
        if (line.amountOfCustomerInLine < 6)
        {
            GameObject newCustomer = Instantiate(customers[Random.Range(0, customers.Length)] , spawnNode.position, Quaternion.identity);
            line.AddCustomer(newCustomer.GetComponent<Customer>());          
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnCustomer();
            yield return new WaitForSeconds(10 / ResourceManager.Instance.Demand);
        }
    }

    public void SetDemand(int num)
    {
        ResourceManager.Instance.Demand = num;
    }

    public void ChangeDemand(int num)
    {
        ResourceManager.Instance.Demand += num;
    }

}
