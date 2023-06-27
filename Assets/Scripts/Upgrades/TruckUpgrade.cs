using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TruckUpgrade : MonoBehaviour
{
    public GameObject truckUpgradeArea,truckUpgradeCount;
    public float cost;
    public TextMeshProUGUI textmesh;
    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount* Time.deltaTime * 4;
        
        if (cost < 0)
        {
            truckUpgradeCount.GetComponent<TruckManager>().truckupgrade = 6;
            truckUpgradeArea.SetActive(false);
        }
    }
}