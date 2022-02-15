using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : GenericSingleton<PlayerTankController>
{
       
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
     
    [SerializeField] Joystick joystick;

    [SerializeField] Rigidbody rb; 

    float xAxis;
    float zAxis;


	protected override void Awake()
	{
		base.Awake();
	}


    void Update()
    {
       // For X axis
       if(joystick.Horizontal >=  0.2f)
       {
           xAxis = speed;
       }
       else if(joystick.Horizontal <= -0.2f)
       {
           xAxis = -speed;
       }       
       else
       {
           xAxis = 0f;
       }
 
       // For Z axis
       if(joystick.Vertical >=  0.2f)
       {
           zAxis = speed;
       }
       else if(joystick.Vertical <= -0.2f)
       {
           zAxis = -speed;
       }       
       else
       {
           zAxis = 0f;
       }

        HandleRotation();
    
    }
   
    void HandleRotation()
    {
        Vector3 moveDirection = new Vector3(joystick.Horizontal,0,joystick.Vertical);
        moveDirection.Normalize();

        if(moveDirection != Vector3.zero)
        {
         Quaternion toRotate = Quaternion.LookRotation(moveDirection,Vector3.up);
         transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotate,rotationSpeed * Time.deltaTime );
        }
     
    }

    void FixedUpdate()
    {
      rb.velocity = new Vector3(xAxis , 0 , zAxis);
    }

    


}
