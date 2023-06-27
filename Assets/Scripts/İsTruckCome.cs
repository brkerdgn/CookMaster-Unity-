using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İsTruckCome : MonoBehaviour
{
    public Animator anim;
    bool isTruckCom;
    public GameObject truckManager,pallet;
    void Start()
    {
        StartCoroutine(isTruckCome());
    }

    IEnumerator isTruckCome()
    {
        while (true)
        {
            if (pallet.GetComponent<TruckManager>().isTruckBoxFull == false)
            {
                if (pallet.GetComponent<TruckManager>().boxList.Count <= 9)
                {
                    anim.SetBool("isTruckComing", true);
                }
                    

            }
            if (pallet.GetComponent<TruckManager>().isTruckBoxFull == true ){ 
                if(pallet.GetComponent<TruckManager>().truckBoxList.Count <= 0)
                {
                    anim.SetBool("isTruckComing", false);
                }   
            }
           
           

            yield return new WaitForSeconds(5);
        }
       
    }  
}
