using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerManager : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("ChangePoint"))
        {
            Destroy(gameObject);   
      
        }
    }
}
