 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnBoxCollect;
    public static TruckManager boxManager;

    public delegate void OnConveyorArea();
    public static event OnConveyorArea OnBoxGive;
    public static ConveyorManager conveyorManager;

    public delegate void OnConveyorPizArea();
    public static event OnConveyorPizArea OnBox1Give;
    public static ConveyorPizza conveyorPizManager;

    public delegate void OnConveyorHotArea();
    public static event OnConveyorHotArea OnBox2Give;
    public static ConveyorHotDog conveyorHotManager;

    public delegate void OnFoodArea();
    public static event OnFoodArea OnHambugerTake;
    public static TableManager tableManager;

    public delegate void OnFoodPizza();
    public static event OnFoodPizza OnPizzaTake;
    public static TableManagerPiz tableManagerPiz;

    public delegate void OnFoodHotdog();
    public static event OnFoodPizza OnHotdogTake;
    public static TableManagerHotDog tableManagerHotdog;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;

    public delegate void OnBuyArea();
    public static event OnBuyArea OnBuyingTable;
    public static BuyTable areaToBuy;

    public delegate void OnTableArea();
    public static event OnTableArea OnFoodGive;
    public static TablesManager tablesManager;

    public delegate void OnGarbageArea();
    public static event OnGarbageArea OnGarbage;

    public delegate void OnLevelArea();
    public static event OnLevelArea OnLevelUpgrade;
    public static LevelUpgrade levelUpgrade;

    public delegate void OnTruckArea();
    public static event OnTruckArea OnTruckUpgrade;
    public static TruckUpgrade truckUpgrade;

    public delegate void OnVonveyorUpgradeArea();
    public static event OnVonveyorUpgradeArea OnConveyorUpgrade;
    public static ConveyorUpgrade conveyorUpgrade;

    public delegate void OnConveyorUpPizArea();
    public static event OnConveyorUpPizArea OnConveyorUpPizza;
    public static ConveyorUpPizza conveyorUpPizza;

    public delegate void OnConveyorUpHotdogArea();
    public static event OnConveyorUpHotdogArea OnConveyorUpHotdog;
    public static ConveyorUpHotdog conveyorUpHotdog;

    public delegate void OnCharUpArea();
    public static event OnCharUpArea OnCharUpgrade;
    public static CharacterUp characterUp;

    public delegate void OnUnlaoderUpgrade();
    public static event OnUnlaoderUpgrade OnUnloaderUp;
    public static  UnloaderUpgrade unloaderUpgrade;

    public delegate void OnWaiterUpgrade();
    public static event OnWaiterUpgrade OnWaiterUp;
    public static WaiterUpgrade waiterUpgrade;

    public Animator animConvUpgrade,animConUpPizza,animConUpHot,animLevelUp,animTruckUp,animArea1, animArea2, animArea3, animArea4, animArea5,animChar,animUnloader,animWaiter;
    bool isCollecting, isGiving, isTaking, isGivingHam, isGarbage, isGiving1,isTakingPiz,isGiving2,isTakingHot;
    void Start()
    {
        StartCoroutine(CollectEnum());
    }

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnBoxCollect();
            }
            if (isGiving == true)
            {
                OnBoxGive();
            }
            if (isGiving1 == true)
            {
                OnBox1Give();
            }
            if (isGiving2 == true)
            {
                OnBox2Give();
            }
            if (isTaking == true)
            {
                OnHambugerTake();
            }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();      
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            animArea1.SetBool("BuyArea1Anim", true);
            animArea2.SetBool("BuyArea2Anim", true);
            animArea3.SetBool("BuyArea3Anim", true);
            animArea4.SetBool("BuyArea4Anim", true);
            animArea5.SetBool("BuyArea5Anim", true);
            OnBuyingTable();
            areaToBuy = other.gameObject.GetComponent<BuyTable>();
        }
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            boxManager = other.gameObject.GetComponent<TruckManager>();
        }
        if (other.gameObject.CompareTag("ConveyorArea"))
        {
            isGiving = true;
            conveyorManager = other.gameObject.GetComponent<ConveyorManager>();

        }
        if (other.gameObject.CompareTag("ConveyorPiz"))
        {
            isGiving1= true;
            conveyorPizManager = other.gameObject.GetComponent<ConveyorPizza>();

        }
        if (other.gameObject.CompareTag("ConveyorHotdog"))
        {
            isGiving2 = true;
            conveyorHotManager = other.gameObject.GetComponent<ConveyorHotDog>();

        }
        if (other.gameObject.CompareTag("FoodArea"))
        {
            tableManager = other.gameObject.GetComponent<TableManager>();
            isTaking = true;
        }
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
        if (other.gameObject.CompareTag("Level"))
        {
            animLevelUp.SetBool("LevelUpAnim", true);
            OnLevelUpgrade();
            levelUpgrade = other.gameObject.GetComponent<LevelUpgrade>();
        }
        if (other.gameObject.CompareTag("Truck"))
        {
            animTruckUp.SetBool("TruckUpAnim", true);
            OnTruckUpgrade();
            truckUpgrade = other.gameObject.GetComponent<TruckUpgrade>();
        }
        if (other.gameObject.CompareTag("ConveyorUpgrade"))
        {
            animConvUpgrade.SetBool("ConveyorHam", true);
            OnConveyorUpgrade();
            conveyorUpgrade = other.gameObject.GetComponent<ConveyorUpgrade>();
        }
        if (other.gameObject.CompareTag("ConveyorUpPizza"))
        {
            animConUpPizza.SetBool("ConveyorUpPizza", true);
            OnConveyorUpPizza();
            conveyorUpPizza = other.gameObject.GetComponent<ConveyorUpPizza>();
        }
        if (other.gameObject.CompareTag("ConveyorUpHotdog"))
        {
            animConUpHot.SetBool("ConveyorUpHotdog", true);
            OnConveyorUpHotdog();
            conveyorUpHotdog = other.gameObject.GetComponent<ConveyorUpHotdog>();
        }
        if (other.gameObject.CompareTag("CharachterUpgrade"))
        {
            animChar.SetBool("CharacterUpAnim", true);
            OnCharUpgrade();
            characterUp = other.gameObject.GetComponent<CharacterUp>();
        }
        if (other.gameObject.CompareTag("UnloaderArea"))
        {
            animUnloader.SetBool("UnloaderAnim", true);
            OnUnloaderUp();
            unloaderUpgrade = other.gameObject.GetComponent<UnloaderUpgrade>();
        }
        if (other.gameObject.CompareTag("WaiterUp"))
        {
            animWaiter.SetBool("WaiterUpAnim", true);
            OnWaiterUp();
            waiterUpgrade = other.gameObject.GetComponent<WaiterUpgrade>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            boxManager = null;
        }
        if (other.gameObject.CompareTag("ConveyorArea"))
        {
            isGiving = false;
            conveyorManager = null;
        }
        if (other.gameObject.CompareTag("ConveyorPiz"))
        {
            isGiving1 = false;
            conveyorPizManager = null;
        }
        if (other.gameObject.CompareTag("ConveyorHotdog"))
        {
            isGiving2 = false;
            conveyorHotManager = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            animArea1.SetBool("BuyArea1Anim", false);
            animArea2.SetBool("BuyArea2Anim", false);
            animArea3.SetBool("BuyArea3Anim", false);
            animArea4.SetBool("BuyArea4Anim", false);
            animArea5.SetBool("BuyArea5Anim", false);
            areaToBuy = null;
        }
        if (other.gameObject.CompareTag("FoodArea"))
        {
            tableManager = null;
            isTaking = false;
        }
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
        if (other.gameObject.CompareTag("Truck"))
        {
            animTruckUp.SetBool("TruckUpAnim", false);
            truckUpgrade = null;
        }
        if (other.gameObject.CompareTag("ConveyorUpgrade"))
        {
            animConvUpgrade.SetBool("ConveyorHam", false);
            conveyorUpgrade = null;
        }
        if (other.gameObject.CompareTag("ConveyorUpPizza"))
        {
            animConUpPizza.SetBool("ConveyorUpPizza", false);
            conveyorUpPizza = null;
        }
        if (other.gameObject.CompareTag("ConveyorUpHotdog"))
        {
            animConUpHot.SetBool("ConveyorUpHotdog", false);
            conveyorUpHotdog = null;
        }
        if (other.gameObject.CompareTag("Level"))
        {
            animLevelUp.SetBool("LevelUpAnim", false);
            levelUpgrade = null;
        }
        if (other.gameObject.CompareTag("CharachterUpgrade"))
        {
            animChar.SetBool("CharacterUpAnim", false);
            characterUp = null;
        }
        if (other.gameObject.CompareTag("UnloaderArea"))
        {
            animUnloader.SetBool("UnloaderAnim", false);
            unloaderUpgrade = null;
        }
        if (other.gameObject.CompareTag("WaiterUp"))
        {
            animWaiter.SetBool("WaiterUpAnim", false);
            waiterUpgrade = null;
        }
    }
}
