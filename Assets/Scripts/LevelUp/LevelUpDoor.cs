using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpDoor : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelUpgrade.isUpgradeLevel == true)
        {
            anim.SetBool("isUpgrade", true);
            anim.SetBool("isFinish", true);
        }
    }
}
