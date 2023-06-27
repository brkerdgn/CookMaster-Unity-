using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public HingeJoint hg;
    JointMotor jointMotor;
   
    public float angle;
    void Start()
    {
        jointMotor = hg.motor;
    }


    void Update()
    {
        angle = hg.angle;
        jointMotor.targetVelocity = -angle;
        hg.motor = jointMotor;
    }
}
