using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public List<GameObject> foodList = new List<GameObject>();
    public List<GameObject> pizzaList = new List<GameObject>();
    public List<GameObject> hotdogList = new List<GameObject>();
    public GameObject boxPrefab, hamburgerPref,pizzaPref,hotdogPref, conveyorManagerHamList,conveyorManagerPizList,conveyorManagerHotList, palleteList, conveyorManagerBoxList, conveyorManagerPizBoxList,conveyorManagerHotBoxList, tableManagerHamCount,tableManagerPizCount,tableManagerHotCount;
    public Transform collectPoint;
    public Animator anim;
    public int boxLimit = 8;
    public float yukseklik = 0;

    private void Start()
    {
    }

    private void OnEnable()
    {
        TriggerManager.OnBoxCollect += GetBox;
        TriggerManager.OnBoxGive += GiveBox;
        TriggerManager.OnBox1Give += GiveBox2;
        TriggerManager.OnBox2Give += GiveBox3;
        TriggerManager.OnHambugerTake += GetFood;
        TriggerManager.OnPizzaTake += GetFood2;
        TriggerManager.OnHotdogTake += GetFood3;
        TriggerManager.OnFoodGive += GiveFood;
        TriggerManager.OnFoodGive += GiveFood2;
        TriggerManager.OnFoodGive += GiveFood3;
        TriggerManager.OnGarbage += GiveGarbage;

    }
    private void OnDisable()
    {
        TriggerManager.OnBoxCollect -= GetBox;
        TriggerManager.OnBoxGive -= GiveBox;
        TriggerManager.OnBox1Give -= GiveBox2;
        TriggerManager.OnBox2Give -= GiveBox3;
        TriggerManager.OnHambugerTake -= GetFood;
        TriggerManager.OnPizzaTake -= GetFood2;
        TriggerManager.OnHotdogTake -= GetFood3;
        TriggerManager.OnFoodGive -= GiveFood;
        TriggerManager.OnFoodGive -= GiveFood2;
        TriggerManager.OnFoodGive -= GiveFood3;
        TriggerManager.OnGarbage -= GiveGarbage;

    }
    void GetBox()
    {
        float minLimit = palleteList.GetComponent<TruckManager>().boxList.Count;
        if(boxList.Count < boxLimit && minLimit > 0)
        {

            GameObject temp = Instantiate(boxPrefab,collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (2f + yukseklik) / 3, collectPoint.position.z);
            boxList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManager.boxManager != null)
            {
                TriggerManager.boxManager.RemoveLast();
            }
        }
    }

  

    void GetFood()
    {
        float minLimit = conveyorManagerHamList.GetComponent<ConveyorManager>().hamburgerNoRBList.Count;
        if (foodList.Count < boxLimit && minLimit > 0)
        {
            GameObject temp = Instantiate(hamburgerPref, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (2f + yukseklik) / 3, collectPoint.position.z);
            foodList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManager.tableManager != null && tableManagerHamCount.GetComponent<TableManager>().hamburgerList.Count > 0)
            {
                TriggerManager.tableManager.RemoveTableFood();
            }
        }
    }
    void GetFood2()
    {
        float minLimit = conveyorManagerPizList.GetComponent<ConveyorPizza>().pizzaNoRBList.Count;
        if (pizzaList.Count < boxLimit && minLimit > 0)
        {
            GameObject temp = Instantiate(pizzaPref, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (2f + yukseklik) / 3, collectPoint.position.z);
            pizzaList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManager.tableManagerPiz != null && tableManagerPizCount.GetComponent<TableManagerPiz>().PizzaList.Count > 0)
            {
                TriggerManager.tableManagerPiz.RemoveTableFood();
            }
        }
    }

    void GetFood3()
    {
        float minLimit = conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList.Count;
        if (hotdogList.Count < boxLimit && minLimit > 0)
        {
            GameObject temp = Instantiate(hotdogPref, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (2f + yukseklik) / 3, collectPoint.position.z);
            hotdogList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManager.tableManagerHotdog != null && tableManagerHotCount.GetComponent<TableManagerHotDog>().HotDogList.Count > 0)
            {
                TriggerManager.tableManagerHotdog.RemoveTableFood();
            }
        }
    }
    void GiveBox()
    {
        float conveyorBoxCount = conveyorManagerBoxList.GetComponent<ConveyorManager>().boxList.Count;
        float conveyorMaxLim = conveyorManagerBoxList.GetComponent<ConveyorManager>().boxLimit;
        if (boxList.Count > 0 && conveyorBoxCount < boxLimit)
        {
            TriggerManager.conveyorManager.GetBox();
            RemoveLast();
        }
    }
    void GiveBox2()
    {
        float conveyorBoxCount = conveyorManagerPizBoxList.GetComponent<ConveyorPizza>().boxList.Count;
        float conveyorMaxLim = conveyorManagerPizBoxList.GetComponent<ConveyorPizza>().boxLimit;
        if (boxList.Count > 0 && conveyorBoxCount < boxLimit)
        {
            TriggerManager.conveyorPizManager.GetBox();
            RemoveLast();
        }
    }

    void GiveBox3()
    {
        float conveyorBoxCount = conveyorManagerHotBoxList.GetComponent<ConveyorHotDog>().boxList.Count;
        float conveyorMaxLim = conveyorManagerHotBoxList.GetComponent<ConveyorHotDog>().boxLimit;
        if (boxList.Count > 0 && conveyorBoxCount < boxLimit)
        {
            TriggerManager.conveyorHotManager.GetBox();
            RemoveLast();
        }
    }
    void GiveFood()
    {
        if (foodList.Count > 0)
        {
                TriggerManager.tablesManager.GetHam();
                TriggerManager.tablesManager.RemoveLastHam();
        }
    }
    void GiveFood2()
    {
        if (pizzaList.Count > 0)
        {
            TriggerManager.tablesManager.GetPizza();
            TriggerManager.tablesManager.RemoveLastPizza();
        }
    }

    void GiveFood3()
    {
        if (hotdogList.Count > 0)
        {
            TriggerManager.tablesManager.GetHotdog();
            TriggerManager.tablesManager.RemoveLastHotDog();
        }
    }



    void GiveGarbage()
    {
        if (boxList.Count > 0)
        {
            yukseklik = yukseklik - 1;
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        } 
        if(foodList.Count > 0)
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
   
    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            yukseklik = yukseklik - 1;
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }

    }

}