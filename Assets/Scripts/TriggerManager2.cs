using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager2 : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea onBoxTakeAI;
    public static TruckManager boxManager;

    public delegate void OnConveyorArea();
    public static event OnConveyorArea OnBoxGiveAI;
    public static ConveyorManager conveyor;

    public delegate void OnConveyorPizArea();
    public static event OnConveyorPizArea OnBox1GiveAI;
    public static ConveyorPizza conveyorPizManager;

    public delegate void OnConveyorHotArea();
    public static event OnConveyorHotArea OnBox2GiveAI;
    public static ConveyorHotDog conveyorHotManager;

    bool isCollectingAI,isGivingAI, isGiving1AI,isGiving2AI;
    void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollectingAI == true)
            {
                onBoxTakeAI();
            }
            if (isGivingAI == true)
            {
                OnBoxGiveAI();
            }
            if (isGiving1AI == true)
            {
                OnBox1GiveAI();
            }
            if (isGiving2AI == true)
            {
                OnBox2GiveAI();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("CollectArea"))
        {
            Debug.Log("CollectArea");
            isCollectingAI = true;
            boxManager = other.gameObject.GetComponent<TruckManager>();
        }
        if (other.gameObject.CompareTag("ConveyorArea"))
        {
            Debug.Log("ConveyorArea");
            isGivingAI = true;
            conveyor = other.gameObject.GetComponent<ConveyorManager>();

        }
        if (other.gameObject.CompareTag("ConveyorPiz"))
        {
            Debug.Log("PizzaArea");
            isGiving1AI = true;
            conveyorPizManager = other.gameObject.GetComponent<ConveyorPizza>();

        }
        if (other.gameObject.CompareTag("ConveyorHotdog"))
        {
            isGiving2AI = true;
            conveyorHotManager = other.gameObject.GetComponent<ConveyorHotDog>();

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollectingAI = false;
            boxManager = null;
        }
        if (other.gameObject.CompareTag("ConveyorArea"))
        {
            isGivingAI = false;
            conveyor = null;
        }
        if (other.gameObject.CompareTag("ConveyorPiz"))
        {
            isGiving1AI = false;
            conveyorPizManager = null;
        }
        if (other.gameObject.CompareTag("ConveyorHotdog"))
        {
            isGiving2AI = false;
            conveyorHotManager = null;
        }
    }
}
