using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyTable : MonoBehaviour
{
   
    public GameObject tableGameObject, buyAreaGameObject,buyAreaSecobject,tables,spawnerArea;
    public float cost,currentMoney,progress;
    public bool isUpgrade;
    public TextMeshProUGUI textmesh;
    public GameObject canvas;

    [SerializeField] TableControl table;
    public int tableNo;

    bool isDone;

    private void Update()
    {
        textmesh.text = Mathf.CeilToInt(cost).ToString();
    }
    public void Buy(int moneyAmount)
    {
        cost -= moneyAmount * Time.deltaTime * 4;


        if (cost <= 0 && !isDone)
        {
            if(spawnerArea.GetComponent<SpawnerArea>().level == 3)
            {
                tables.GetComponent<TableControl>().tableCountForWaiter++;
            }
            canvas.SetActive(false);
            isDone = true;
            buyAreaGameObject.SetActive(false);
            tableGameObject.SetActive(true); 
            buyAreaSecobject.SetActive(true);
            isUpgrade = true;
            table.tableCount++;
            table.isTableEmpty[tableNo] = true;
        }
       
    }
}
