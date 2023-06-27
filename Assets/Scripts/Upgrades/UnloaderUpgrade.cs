using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnloaderUpgrade : MonoBehaviour
{
    public GameObject unloaderUpgradeArea, carrier,carrierFake;
    public float cost;
    public TextMeshProUGUI textmesh;
    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 4;

        if (cost < 0)
        {
            carrierFake.SetActive(false);
            carrier.SetActive(true);
            unloaderUpgradeArea.SetActive(false);
        }
    }
}
