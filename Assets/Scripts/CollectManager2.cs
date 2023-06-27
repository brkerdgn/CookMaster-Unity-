using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager2 : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab, palleteList, conveyorManagerBoxList, conveyorManagerPizBoxList, conveyorManagerHotBoxList;
    public Transform collectPoint;
    int boxLimit = 4;
    public float yukseklik = 0;

    private void OnEnable()
    {
        TriggerManager2.onBoxTakeAI += GetBox;
        TriggerManager2.OnBoxGiveAI += GiveBox;
        TriggerManager2.OnBox1GiveAI += GiveBox2;
        TriggerManager2.OnBox2GiveAI += GiveBox3;
    }
    private void OnDisable()
    {
        TriggerManager2.onBoxTakeAI -= GetBox;
        TriggerManager2.OnBoxGiveAI -= GiveBox;
        TriggerManager2.OnBox1GiveAI -= GiveBox2;
        TriggerManager2.OnBox2GiveAI -= GiveBox3;

    }

    void GetBox()
    {
        float minLimit = palleteList.GetComponent<TruckManager>().boxList.Count;
        if (boxList.Count < boxLimit && minLimit > 0)
        {

            GameObject temp = Instantiate(boxPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, (3f + yukseklik) / 3, collectPoint.position.z);
            boxList.Add(temp);
            yukseklik = yukseklik + 1;
            if (TriggerManager2.boxManager != null)
            {
                TriggerManager2.boxManager.RemoveLast();
            }
        }
    }
    void GiveBox()
    {
        float conveyorBoxCount = conveyorManagerBoxList.GetComponent<ConveyorManager>().boxList.Count;
        float conveyorMaxLim = conveyorManagerBoxList.GetComponent<ConveyorManager>().boxLimit;
        if (boxList.Count > 0 && conveyorBoxCount < conveyorMaxLim)
        {
            TriggerManager2.conveyor.GetBox();
            RemoveLast();
        }
    }

    void GiveBox2()
    {
        float conveyorBoxCount = conveyorManagerPizBoxList.GetComponent<ConveyorPizza>().boxList.Count;
        float conveyorMaxLim = conveyorManagerPizBoxList.GetComponent<ConveyorPizza>().boxLimit;
        if (boxList.Count > 0 && conveyorBoxCount < conveyorMaxLim)
        {
            TriggerManager2.conveyorPizManager.GetBox();
            RemoveLast();
        }
    }

    void GiveBox3()
    {
        float conveyorBoxCount = conveyorManagerHotBoxList.GetComponent<ConveyorHotDog>().boxList.Count;
        float conveyorMaxLim = conveyorManagerHotBoxList.GetComponent<ConveyorHotDog>().boxLimit;
        if (boxList.Count > 0 && conveyorBoxCount < conveyorMaxLim)
        {
            TriggerManager2.conveyorHotManager.GetBox();
            RemoveLast();
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

    private void Update()
    {
        Debug.Log(TriggerManager2.conveyorPizManager);
        Debug.Log(TriggerManager2.conveyor);
    }

}
