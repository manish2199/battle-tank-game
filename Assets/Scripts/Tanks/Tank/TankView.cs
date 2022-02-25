using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public abstract class TankView : MonoBehaviour
{
    
    public TankController playerController;

    
    [SerializeField] private Transform tankTransform;
    public Transform TankTransform   { get { return tankTransform;} }  


    [SerializeField] private Transform bulletFireTransform;
    public Transform BulletFireTransform { get { return bulletFireTransform;} } 

    [HideInInspector]public int health ;

    void Start()
    {
        health = playerController.tankModelScript.Health;
    }

    void Update()
    {
        tankMovement();      
 
        handleTankRotation(); 
    }

    public abstract void destroyTank();
    // {
    //     Destroy(this.gameObject);
    // }

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
    }

    public void handleTankRotation()
    {
        float xAxis = playerController.RotationJoystick.Horizontal;

        if(Mathf.Abs(xAxis) > 0.3f)
        {
           playerController.tankRotation();
        }
    }
  

    public abstract void destroyBullet(BulletView bullet);

}
