using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerTriggerManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyHamburger"))
        {
            Destroy(gameObject);
        }
    }
 
}
