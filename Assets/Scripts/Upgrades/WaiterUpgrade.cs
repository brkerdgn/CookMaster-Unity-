using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaiterUpgrade : MonoBehaviour
{
    public GameObject waiterUpArea,waiter,waiterFake;
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
            waiter.SetActive(true);
            waiterFake.SetActive(false);
            waiterUpArea.SetActive(false);
        }
       
        
    }
}
