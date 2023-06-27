using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManagerHotDog : MonoBehaviour
{
    public GameObject conveyorManagerHotList;
    public List<GameObject> HotDogList = new List<GameObject>();

    public void RemoveTableFood()
    {
        if (HotDogList.Count > 0 && conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList.Count > 0)
        {
            Destroy(HotDogList[HotDogList.Count - 1]);
            HotDogList.RemoveAt(HotDogList.Count - 1);
            Destroy(conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList[conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList.Count - 1]);
            conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList.RemoveAt(conveyorManagerHotList.GetComponent<ConveyorHotDog>().hotDogNoRBList.Count - 1);

        }
    }
}
