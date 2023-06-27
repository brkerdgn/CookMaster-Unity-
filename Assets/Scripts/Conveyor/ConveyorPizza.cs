using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ConveyorPizza : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public List<GameObject> boxConList = new List<GameObject>();
    public List<GameObject> pizzaList = new List<GameObject>();
    public List<GameObject> pizzaNoRBList = new List<GameObject>();

    public Transform boxPoint, conveyorTakePoint, changePoint, dropFoodPoint;
    public GameObject boxPrefab, conveyorBoxPrefab, pizza, hamburgerNoRB;
    public int stackCount = 4, boxLimit = 8, pizzaLimit = 12;
    public TextMeshProUGUI boxlist, boxlimit;
    public float convUpgradeTime = 4.0f;
    public GameObject table;

    private void Start()
    {

        StartCoroutine(BoxToConveyor());
        StartCoroutine(BoxToFood());
        StartCoroutine(FoodToNORBFood());
    }

    IEnumerator BoxToConveyor()
    {
        while (true)
        {
            if (boxList.Count > 0 && pizzaLimit > pizzaNoRBList.Count)
            {
                GameObject temp = Instantiate(conveyorBoxPrefab);
                temp.transform.position = new Vector3(conveyorTakePoint.position.x, conveyorTakePoint.position.y, conveyorTakePoint.position.z);
                boxConList.Add(temp);
                RemoveLast();
            }
            yield return new WaitForSeconds(2.0f);
        }

    }

    IEnumerator BoxToFood()
    {
        while (true)
        {
            if (boxConList.Count > 0 && pizzaLimit > pizzaNoRBList.Count)
            {
                GameObject tmp = Instantiate(pizza);
                tmp.transform.position = new Vector3(changePoint.position.x, changePoint.position.y, changePoint.position.z);
                pizzaList.Add(tmp);
                RemoveLastBoxConv();

            }
            yield return new WaitForSeconds(convUpgradeTime);
        }

    }

    IEnumerator FoodToNORBFood()
    {
        while (true)
        {

            yield return new WaitForSeconds(convUpgradeTime - 0.5f);
            if (pizzaList.Count > 0 && pizzaLimit > pizzaNoRBList.Count)
            {
                float hamburgerNoRBListCount = pizzaNoRBList.Count;
                int rowCount = (int)hamburgerNoRBListCount / stackCount;
                GameObject tmp = Instantiate(hamburgerNoRB);
                tmp.transform.position = new Vector3(dropFoodPoint.position.x + (0.2f + (float)rowCount / 3), (0.4f + (hamburgerNoRBListCount % stackCount) / 3), dropFoodPoint.position.z);
                pizzaNoRBList.Add(tmp);
                table.GetComponent<TableManagerPiz>().PizzaList.Add(tmp);
                RemoveLastFoodConv();
            }


        }
    }

    private void Update()
    {

        boxlist.text = boxList.Count.ToString();
        boxlimit.text = boxLimit.ToString();
    }


    public void GetBox()
    {
        float boxListCount = boxList.Count;
        if (boxLimit > boxListCount)
        {
            int rowCount = (int)boxListCount / stackCount;
            GameObject temp = Instantiate(boxPrefab);
            temp.transform.position = new Vector3(boxPoint.position.x + ((float)rowCount / 3), (0.5f + (boxListCount % stackCount) / 3), boxPoint.position.z);
            boxList.Add(temp);
        }
    }

    public void RemoveLastFoodConv()
    {
        if (pizzaList.Count > 0)
        {
            Destroy(pizzaList[pizzaList.Count - 1]);
            pizzaList.RemoveAt(pizzaList.Count - 1);
        }
    }

    public void RemoveLastBoxConv()
    {
        if (boxConList.Count > 0)
        {
            Destroy(boxConList[boxConList.Count - 1]);
            boxConList.RemoveAt(boxConList.Count - 1);
        }
    }

    public void RemoveLast()
    {
        if (boxList.Count > 0 && pizzaLimit > pizzaNoRBList.Count)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }

    }


}
