using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public PlayerTankController playerController;

    [SerializeField] private Transform tankTransform;
    public Transform TankTransform   { get { return tankTransform;} }  


    void Start()
    {
        print(playerController.tankModelScript.tankType + " has been created " );
    }


    void Update()
    {
        tankMovement();      
 
        handleTankRotation(); 
    }


    public void tankMovement()
    {
        // For Z axis
       if(playerController.MovementJoystick.Vertical >=  0.2f)
       {
            playerController.moveTankForward();
       }
       else if(playerController.MovementJoystick.Vertical <= -0.2f)
       {
            playerController.moveTankBackWard();
       }       
       else
       {}
    }

    public void handleTankRotation()
    {
        float xAxis = playerController.RotationJoystick.Horizontal;

        if(Mathf.Abs(xAxis) > 0.3f)
        {
           playerController.tankRotation();
        }
    }

   

}
