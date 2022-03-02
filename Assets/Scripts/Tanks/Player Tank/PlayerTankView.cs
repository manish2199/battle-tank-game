using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTankView : TankView , IDamagable
{  
    public PlayerTankController playerTankController;   
  
    [SerializeField] private Transform bulletFireTransform;
    public Transform BulletFireTransform { get { return bulletFireTransform;}  } 

    void OnEnable()
    { 
       PlayerTankService.IncrementScore += increaseScore;
    }

    void OnDisable()
    {
       PlayerTankService.IncrementScore -= increaseScore;
    }

    void increaseScore()
    {
        playerTankController.IncreasePlayerTankScore();
    }

    void Start()
    {
        playerTankController.SetFireButtonFunction();
    }

    public void Update()
    {
        this.tankMovement();      
 
        this.handleTankRotation(); 
    }

    public void TakeDamage(BulletType bulletType , int damage, BulletView bullet)
    {
        playerTankController.applyDamage(bulletType , damage , bullet );
    }
    
    public override void destroyTank()
    {
        Destroy(this.gameObject);
    }
   
    public override void tankMovement()
    {
        // For Z axis
       if(playerTankController.MovementJoystick.Vertical >=  0.2f)
       {
            playerTankController.moveTankForward();
       }
       else if(playerTankController.MovementJoystick.Vertical <= -0.2f)
       {
            playerTankController.moveTankBackWard();
       }       
    }


    public override void handleTankRotation()
    {
        float xAxis = playerTankController.RotationJoystick.Horizontal;

        if(Mathf.Abs(xAxis) > 0.3f)
        {
           playerTankController.tankRotation();
        }
    }
}
