using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public FloatingJoystick FloatingJoystick;
    public Rigidbody rb;
    public Animator anim;
    public GameObject charachter,u�joysticTut;


    private void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * FloatingJoystick.Vertical + Vector3.right * FloatingJoystick.Horizontal;
        rb.velocity = direction * speed * Time.deltaTime;
        if(charachter.GetComponent<CollectManager>().boxList.Count > 0 || charachter.GetComponent<CollectManager>().foodList.Count > 0 || charachter.GetComponent<CollectManager>().pizzaList.Count > 0)
        {
            anim.SetBool("isCarrying", true);
            if (FloatingJoystick.Horizontal != 0 || FloatingJoystick.Vertical != 0)
            {
                u�joysticTut.SetActive(false);
                transform.rotation = Quaternion.LookRotation(rb.velocity);
                anim.SetBool("isRunAndCarrying", true);
            }
            else
            {
                anim.SetBool("isRunAndCarrying", false);
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isCarrying", false);
            if (FloatingJoystick.Horizontal != 0 || FloatingJoystick.Vertical != 0)
            {
                u�joysticTut.SetActive(false);
                transform.rotation = Quaternion.LookRotation(rb.velocity);
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
             
    }

}
