using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManagerWaiter : MonoBehaviour
{
    public delegate void OnFoodPizza();
    public static event OnFoodPizza OnPizzaTake;
    public static TableManagerPiz tableManagerPiz;

    public delegate void OnFoodHotdog();
    public static event OnFoodPizza OnHotdogTake;
    public static TableManagerHotDog tableManagerHotdog;

    public delegate void OnTableArea();
    public static event OnTableArea OnFoodGive;
    public static TablesManager tablesManager;

    public delegate void OnGarbageArea();
    public static event OnGarbageArea OnGarbage;

    bool isTakingPiz, isTakingHot,isGivingHam,isGarbage;

    void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isTakingPiz == true)
            {
                OnPizzaTake();
            }
            if (isTakingHot == true)
            {
                OnHotdogTake();
            }
            if (isGivingHam == true)
            {
                OnFoodGive();
            }
            if (isGarbage == true)
            {
                OnGarbage();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FoodPiz"))
        {
            tableManagerPiz = other.gameObject.GetComponent<TableManagerPiz>();
            isTakingPiz = true;
        }
        if (other.gameObject.CompareTag("FoodHotdog"))
        {
            tableManagerHotdog = other.gameObject.GetComponent<TableManagerHotDog>();
            isTakingHot = true;
        }
        if (other.gameObject.CompareTag("Tables"))
        {
            isGivingHam = true;
            tablesManager = other.gameObject.GetComponent<TablesManager>();
        }
        if (other.gameObject.CompareTag("Garbage"))
        {
            isGarbage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FoodPiz"))
        {
            tableManagerPiz = null;
            isTakingPiz = false;
        }
        if (other.gameObject.CompareTag("FoodHotdog"))
        {
            tableManagerHotdog = null;
            isTakingHot = false;
        }
        if (other.gameObject.CompareTag("Tables"))
        {
            isGivingHam = false;
            tablesManager = null;
        }
        if (other.gameObject.CompareTag("Garbage"))
        {
            isGarbage = false;
        }
    }
}
