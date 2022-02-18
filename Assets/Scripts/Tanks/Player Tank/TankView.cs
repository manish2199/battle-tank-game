using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; 
    
    private Joystick movementJoystick;
    private Joystick rotationJoystick;

    private float xAxis,zAxis;

    private float tankSpeed;
    public float TankSpeed { set{ tankSpeed = value;}}

    private float rotationSpeed;
    public float RotationSpeed { set{ rotationSpeed = value;}}

   [SerializeField]private Transform tankTransform ;
    public Transform TankTransform   { get { return tankTransform;} }  

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
       }
       else if(movementJoystick.Vertical <= -0.2f)
       {
           transform.position -= transform.forward * Time.deltaTime * tankSpeed; 
       }       
       else
       {}
    }

    public void handleTankRotation()
    {
        xAxis = rotationJoystick.Horizontal;
       
        transform.Rotate(0, xAxis * rotationSpeed * Time.deltaTime , 0);
    }

   

}
