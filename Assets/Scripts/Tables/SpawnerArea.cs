using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerArea : MonoBehaviour
{
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] TableControl table;
    public int level;

    // spawn süresi
    [SerializeField] float min, max;

    // spawn esnasýnda müþteriler arasýdaki mesafe
    [SerializeField] float distance = 0.1f;

    int groupSize;
    float timer;
    int j;

    private void Update()
    {
        if (table.tableCount != 0)
            timer += Time.deltaTime;

        if (timer > Random.Range(min, max) && table.tableCount != 0)
        {
            timer = 0f;
            groupSize = Random.Range(1, 3);

            // müsait olan masayý belirleme
            for (j = 0; j < table.tables.Length ; j++)
            {
                if (table.isTableEmpty[j])
                {
                    table.isTableEmpty[j] = false;
                    table.tableCount--;
                    break;
                }
            }
            // müþteriyi oluþturma
            for (int i = 0; i < groupSize; i++)
            { 
                GameObject go = Instantiate(customerPrefabs[Random.Range(0, customerPrefabs.Length)], spawnPoint.position + new Vector3(0f, 0f, i * distance), Quaternion.identity);
                go.GetComponent<NavMesh>().WalkToTable(table.tables[j].GetChild(i).transform);
                go.GetComponent<NavMesh>().settedTable = j;
                table.transform.GetChild(j).GetComponent<TablesManager>().customers.Add(go);
                
                switch (level)
                {
                    case 1:
                        table.burgerOrder[j] += go.GetComponent<NavMesh>().BurgerOrder();
                        break;
                    case 2:
                        table.burgerOrder[j] += go.GetComponent<NavMesh>().BurgerOrder();
                        table.pizzaOrder[j] += go.GetComponent<NavMesh>().PizzaOrder();
                        break;
                    case 3:
                        table.hutDogOrder[j] += go.GetComponent<NavMesh>().HotDogOrder();
                        table.pizzaOrder[j] += go.GetComponent<NavMesh>().PizzaOrder();
                        break;
                }
            }
        }
    }
}
