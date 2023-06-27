using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUp2 : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

       
       
        SceneManager.LoadScene(2);
        LevelUpgrade.isUpgradeLevel = false;
       
    }

}
