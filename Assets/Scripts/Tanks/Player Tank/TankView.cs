using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public Rigidbody rb; 

    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    float xAxis,zAxis;

    bool notMoving = false;

    [HideInInspector] public float tankSpeed;

    [HideInInspector] public float rotationSpeed;


    void Awake()
    {
        GameObject temp = GameObject.Find("Canvas/Fixed Joystick");
        movementJoystick = temp.GetComponent<Joystick>();
    
        GameObject temp1 = GameObject.Find("Canvas/Fixed Joystick 1");
        rotationJoystick = temp1.GetComponent<Joystick>();
    }

     void Update()
    {
        tankMovement();      
 
        handleTankRotation(); 
    }

    public void tankMovement()
    {
        // For Z axis
       if(movementJoystick.Vertical >=  0.2f)
       {
           transform.position += transform.forward * Time.deltaTime * tankSpeed;
           notMoving = false;
       }
       else if(movementJoystick.Vertical <= -0.2f)
       {
            transform.position -= transform.forward * Time.deltaTime * tankSpeed; 
           notMoving = false;
       }       
       else
       {
           notMoving = true;
       }
    }

    public void handleTankRotation()
    {
        xAxis = rotationJoystick.Horizontal;
       
        if(notMoving)
        {
           transform.Rotate(0, xAxis * rotationSpeed * Time.deltaTime , 0);
        }

        // Vector3 moveDirection = new Vector3(joystick.Horizontal,0,joystick.Vertical);
        // moveDirection.Normalize();
        // // Transform tankTrns = TankV.tankTransform;
        
        // if(moveDirection != Vector3.zero)
        // {
        //  Quaternion toRotate = Quaternion.LookRotation(moveDirection,Vector3.up);
        //  transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotate,rotationSpeed * Time.deltaTime );
        // }
    }

   

}
