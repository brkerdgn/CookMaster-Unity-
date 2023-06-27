using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUp : MonoBehaviour
{
    public GameObject charachterUpgradeArea, charachter;
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
            charachter.GetComponent<CollectManager>().boxLimit = 10;
            charachterUpgradeArea.SetActive(false);
        }
    }
}
