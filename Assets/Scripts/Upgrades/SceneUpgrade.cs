using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpgrade : MonoBehaviour
{
   
   
    private void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene(1);
        LevelUpgrade.isUpgradeLevel = false;
    }

}
