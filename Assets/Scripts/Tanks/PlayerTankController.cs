using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : GenericSingleton<PlayerTankController>
{
       
    [SerializeField] float speed;
     
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
       xAxis =joystick.Horizontal * speed;
       zAxis = joystick.Vertical  * speed;

       HandleRotation();
    
    }
   
    void HandleRotation()
    {
        if(zAxis > 0)
       {
          transform.Rotate(0 , 0 , 0);
       }
        if(zAxis < 0)
       {
          transform.Rotate(0 , -180 , 0);
       }
       if(xAxis > 0)
       {
          transform.Rotate(0 , -90 , 0);
       }
         if(xAxis > 0)
       {
          transform.Rotate(0 , 90 , 0);
       }

    }

    void FixedUpdate()
    {
      rb.velocity = new Vector3(xAxis , 0 , zAxis);
    }

    


}
