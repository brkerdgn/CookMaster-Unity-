using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TruckManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public List<GameObject> truckBoxList = new List<GameObject>();
    public float boxLimit = 4, boxGiveLimit = 12;
    public GameObject boxPrefab;
    public Transform exitPoint, dropPoint;
    public bool isWorking,isTruckBoxFull;
    public int stackCount = 3;
    public int truckupgrade = 4;
    private void Start()
    {
        StartCoroutine(BoxComing());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TruckPoint"))
        {
            isWorking = true;
            isTruckBoxFull = true;
            Invoke("TruckBoxSpawn",0.1f);

        }
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TruckPoint"))
        {
            isWorking = false;
            isTruckBoxFull = false;
        }
    }

    void TruckBoxSpawn()
    {

      
      for (int i = 0; i < truckupgrade; i++)
       {       
         float boxListCount = truckBoxList.Count;
         int rowCount = (int)boxListCount / stackCount;
         GameObject temp = Instantiate(boxPrefab);
         temp.transform.position = new Vector3(dropPoint.position.x + ((float)rowCount / 3), (1.1f + (boxListCount % stackCount) / 3), dropPoint.position.z);
         truckBoxList.Add(temp);
      }
        
    }

  
    IEnumerator BoxComing()
    {
        while (true)
        {
            float boxListCount = boxList.Count;
            int rowCount = (int)boxListCount / stackCount;
            if (isWorking == true)
            {
                GameObject temp = Instantiate(boxPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x - ((float)rowCount / 3), (boxListCount % stackCount) / 3, exitPoint.position.z);
                boxList.Add(temp);
                RemoveLastBoxFromTruck();
                if (isTruckBoxFull == false)
                {
                    isWorking = false;
                   
                }
            }
           
            yield return new WaitForSeconds(2.2f);
        }
    }

    public void RemoveLastBoxFromTruck()
    {
        if (truckBoxList.Count > 0)
        {
            Destroy(truckBoxList[truckBoxList.Count - 1]);
            truckBoxList.RemoveAt(truckBoxList.Count - 1);
        }
    }

    public void RemoveLast()
    {
        if (boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
   

}