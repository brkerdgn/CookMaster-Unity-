using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public float moneyCount = 0;
    public Text text;

    private void OnEnable()
    {
        TriggerManager.OnMoneyCollected += IncreaseMoney;
        TriggerManager.OnBuyingTable += BuyArea;
        TriggerManager.OnLevelUpgrade += Level;
        TriggerManager.OnTruckUpgrade += TruckUp;
        TriggerManager.OnConveyorUpgrade += ConveyorUpgrade;
        TriggerManager.OnConveyorUpPizza += ConveyorUpgradePizza;
        TriggerManager.OnConveyorUpHotdog += ConveyorUpgradeHotdog;
        TriggerManager.OnCharUpgrade += CharacterUpgrade;
        TriggerManager.OnUnloaderUp += UnloaderUpgrade;
        TriggerManager.OnWaiterUp += WaiterUp;
    }

    private void OnDisable()
    {
        TriggerManager.OnMoneyCollected -= IncreaseMoney;
        TriggerManager.OnBuyingTable -= BuyArea;
        TriggerManager.OnLevelUpgrade -= Level;
        TriggerManager.OnTruckUpgrade -= TruckUp;
        TriggerManager.OnConveyorUpgrade -= ConveyorUpgrade;
        TriggerManager.OnConveyorUpPizza -= ConveyorUpgradePizza;
        TriggerManager.OnConveyorUpHotdog -= ConveyorUpgradeHotdog;
        TriggerManager.OnCharUpgrade -= CharacterUpgrade;
        TriggerManager.OnUnloaderUp -= UnloaderUpgrade;
        TriggerManager.OnWaiterUp -= WaiterUp;
    }

    void IncreaseMoney()
    {
        moneyCount += 1;
    }
    private void Update()
    {
        text.text = Mathf.CeilToInt(moneyCount).ToString();
    }
    void BuyArea()
    {
        if (TriggerManager.areaToBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.areaToBuy.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }

    void ConveyorUpgrade()
    {
        if (TriggerManager.conveyorUpgrade != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.conveyorUpgrade.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }

    void ConveyorUpgradePizza()
    {
        if (TriggerManager.conveyorUpPizza != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.conveyorUpPizza.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }

    void ConveyorUpgradeHotdog()
    {
        if (TriggerManager.conveyorUpHotdog != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.conveyorUpHotdog.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }
    void Level()
    {
        if (TriggerManager.levelUpgrade != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.levelUpgrade.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 12;
            }
        }
    }
    void TruckUp()
    {
        if (TriggerManager.truckUpgrade != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.truckUpgrade.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }

    void UnloaderUpgrade()
    {
        if (TriggerManager.unloaderUpgrade != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.unloaderUpgrade.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }

    void WaiterUp()
    {
        if (TriggerManager.waiterUpgrade != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.waiterUpgrade.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }

    void CharacterUpgrade()
    {
        if (TriggerManager.characterUp != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.characterUp.Buy(1);
                moneyCount -= 1 * Time.deltaTime * 4;
            }
        }
    }
}