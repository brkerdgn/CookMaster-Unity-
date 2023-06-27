using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ConveyorUpPizza : MonoBehaviour
{
    public GameObject conveyorUpgradeArea, conveyorUpgradeCount, conveyorLine;
    public float cost;
    public TextMeshProUGUI textmesh;
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 4;

        if (cost <= 0)
        {
            conveyorLine.GetComponent<CýnveyorLine>().materialSpeed = 0.85f;
            conveyorUpgradeCount.GetComponent<ConveyorPizza>().convUpgradeTime = 3;
            conveyorUpgradeCount.GetComponent<ConveyorPizza>().boxLimit = 12;
            conveyorUpgradeCount.GetComponent<ConveyorPizza>().pizzaLimit = 12;
            conveyorUpgradeArea.SetActive(false);
        }
    }

    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
}
