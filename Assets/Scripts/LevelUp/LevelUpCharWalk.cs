using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LevelUpCharWalk : MonoBehaviour
{
    public Rigidbody rb;
    public Transform charachterUpgradePoint;
    public float speed;
    public Animator anim;
    void Start()
    {
       
    }
  
      
  
    // Update is called once per frame
    void Update()
    {
     if (LevelUpgrade.isUpgradeLevel == true)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
            transform.Translate(0, 0, 1 * Time.deltaTime * speed);
            anim.SetBool("isRunning", true);

        }
    }
}
