using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableControl : MonoBehaviour
{
    // tablelar�n tutuldu�u transform arrayi
    public Transform[] tables;

    // masa m�saitli�ini kontrol eden array
    public bool[] isTableEmpty,isCame,isCameWaiter;

    // m�sait olan say� miktar�
    public int tableCount,tableCountForWaiter;

    // verilen sipari�ler
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
