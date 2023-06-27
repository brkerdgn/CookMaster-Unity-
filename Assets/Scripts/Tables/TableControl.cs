using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour
{
    // tablelarýn tutulduðu transform arrayi
    public Transform[] tables;

    // masa müsaitliðini kontrol eden array
    public bool[] isTableEmpty,isCame,isCameWaiter;

    // müsait olan sayý miktarý
    public int tableCount,tableCountForWaiter;

    // verilen sipariþler
    public int[] burgerOrder = new int[5];
    public int[] pizzaOrder = new int[5];
    public int[] hutDogOrder = new int[5];

    public void ClearTable(int tableNo)
    {
        isCame[tableNo] = false;
        isTableEmpty[tableNo] = true;
        tableCount++;
        burgerOrder[tableNo] = 0;
        pizzaOrder[tableNo] = 0;
        hutDogOrder[tableNo] = 0;
    }
}
