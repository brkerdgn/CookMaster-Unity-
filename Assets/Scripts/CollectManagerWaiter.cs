using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManagerWaiter : MonoBehaviour
{
    public List<GameObject> foodList = new List<GameObject>();
    public List<GameObject> pizzaList = new List<GameObject>();
    public List<GameObject> hotdogList = new List<GameObject>();
    public GameObject conveyorManagerPizList, tableManagerPizCount, pizzaPref, conveyorManagerHotList, tableManagerHotCount, hotdogPref;
    public int boxLimit = 4;
    public Transform collectPoint;
    public float yukseklik = 0;

    private void OnEnable()
    {
        TriggerManagerWaiter.OnPizzaTake += GetFoodPiz;
        TriggerManagerWaiter.OnHotdogTake += GetFoodHot;
        TriggerManagerWaiter.OnFoodGive += GiveFoodHam;
        TriggerManagerWaiter.OnFoodGive += GiveFoodPiz;
        TriggerManagerWaiter.OnFoodGive += GiveFoodHot;
        TriggerManagerWaiter.OnGarbage += GiveGarbage;

    }

    private void OnDisable()
    {
        TriggerManagerWaiter.OnPizzaTake -= GetFoodPiz;
        TriggerManagerWaiter.OnHotdogTake -= GetFoodHot;
        TriggerManagerWaiter.OnFoodGive -= GiveFoodHam;
        TriggerManagerWaiter.OnFoodGive -= GiveFoodPiz;
        TriggerManagerWaiter.OnFoodGive -= GiveFoodHot;
        TriggerManagerWaiter.OnGarbage -= GiveGarbage;

    }

    void GetFoodPiz()
    {
        float minLimit = conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList.Count;
        if (pizzaList.Count < boxLimit && minLimit > 0)
        {
            GameObject temp = Instantiate(pizzaPref, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (3f + yukseklik) / 3, collectPoint.position.z);
            pizzaList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManagerWaiter.tableManagerPiz != null && tableManagerPizCount.GetComponent<TableManagerPiz>().PizzaList.Count > 0)
            {
                TriggerManagerWaiter.tableManagerPiz.RemoveTableFood();
            }
        }
    }

    void GetFoodHot()
    {
        float minLimit = conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList.Count;
        if (hotdogList.Count < boxLimit && minLimit > 0)
        {
            GameObject temp = Instantiate(hotdogPref, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (3f + yukseklik) / 3, collectPoint.position.z);
            hotdogList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManagerWaiter.tableManagerHotdog != null && tableManagerHotCount.GetComponent<TableManagerHotDog>().HotDogList.Count > 0)
            {
                TriggerManagerWaiter.tableManagerHotdog.RemoveTableFood();
            }
        }
    }

    void GiveFoodHam()
    {
        if (foodList.Count > 0)
        {
            TriggerManagerWaiter.tablesManager.GetHam();
            TriggerManagerWaiter.tablesManager.RemoveLastHam();
        }
    }

    void GiveFoodPiz()
    {
        if (pizzaList.Count > 0)
        {
            TriggerManagerWaiter.tablesManager.GetPizzaForWaiter();
            TriggerManagerWaiter.tablesManager.RemoveLastPizzaForWaiter();
        }
    }

    void GiveFoodHot()
    {
        if (hotdogList.Count > 0)
        {
            TriggerManagerWaiter.tablesManager.GetHotdogForWaiter();
            TriggerManagerWaiter.tablesManager.RemoveLastHotDogForWaiter();
        }
    }

    void GiveGarbage()
    {
        if (foodList.Count > 0)
        {
            yukseklik = yukseklik - 1;
            Destroy(foodList[foodList.Count - 1]);
            foodList.RemoveAt(foodList.Count - 1);
        }
        if (pizzaList.Count > 0)
        {
            yukseklik = yukseklik - 1;
            Destroy(pizzaList[pizzaList.Count - 1]);
            pizzaList.RemoveAt(pizzaList.Count - 1);
        }
        if (hotdogList.Count > 0)
        {
            yukseklik = yukseklik - 1;
            Destroy(hotdogList[hotdogList.Count - 1]);
            hotdogList.RemoveAt(hotdogList.Count - 1);
        }
    }
}
