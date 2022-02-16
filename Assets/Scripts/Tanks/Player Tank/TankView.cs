using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public Rigidbody rb; 

    public Joystick joystick;

    float xAxis,zAxis;

    [HideInInspector] public float tankSpeed;

    [HideInInspector] public float rotationSpeed;

    void Awake()
    {
        GameObject temp = GameObject.Find("Canvas/Fixed Joystick");
        joystick = temp.GetComponent<Joystick>();
    }


    public void tankInputs()
    {
        // For X axis
       if(joystick.Horizontal >=  0.2f)
       {
           xAxis = tankSpeed;
       }
       else if(joystick.Horizontal <= -0.2f)
       {
           xAxis = -(tankSpeed);
       }       
       else
       {
           xAxis = 0f;
       }
 
       // For Z axis
       if(joystick.Vertical >=  0.2f)
       {
           zAxis = tankSpeed;
       }
       else if(joystick.Vertical <= -0.2f)
       {
           zAxis = -(tankSpeed);
       }       
       else
       {
           zAxis = 0f;
       }

    }

    public void handleTankRotation()
    {
        Vector3 moveDirection = new Vector3(joystick.Horizontal,0,joystick.Vertical);
        moveDirection.Normalize();
        // Transform tankTrns = TankV.tankTransform;
        
        if(moveDirection != Vector3.zero)
        {
         Quaternion toRotate = Quaternion.LookRotation(moveDirection,Vector3.up);
         transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotate,rotationSpeed * Time.deltaTime );
        }
    }

    void Update()
    {
        tankInputs();      
 
        handleTankRotation();
    }

    void FixedUpdate()
    {
       rb.velocity = new Vector3(xAxis, 0 ,zAxis);
    }

}
