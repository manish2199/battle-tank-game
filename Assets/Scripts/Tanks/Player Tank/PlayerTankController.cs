using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerTankController : TankController 
{     
    public Button FireButton { get; set;  }  
     
    public Joystick MovementJoystick { get; set; }

    public Joystick RotationJoystick { get; set; } 
    
    public  PlayerTankView playerTankViewScript;

    private int noOFBulletShots = 0;

    public PlayerTankController(TankModel tankModel , GameObject tankPrefab , Button fireButton , Joystick movementJoystick , Joystick rotationJoystick , Transform positionToInstantiate)
    { 
       tankModelScript = tankModel;

       GameObject temp  = GameObject.Instantiate(tankPrefab,positionToInstantiate);
       playerTankViewScript = temp.GetComponent<PlayerTankView>();

       MovementJoystick = movementJoystick ;
       RotationJoystick = rotationJoystick;
       FireButton = fireButton;

       playerTankViewScript.playerTankController = this; 
    } 

    
    public void IncreasePlayerTankScore()
    {
        tankModelScript.Score ++;
        PlayerTankService.Instance.TriggerUpdateScoreEvent(tankModelScript.Score);
    }
     
    public override void SetFireButtonFunction()
    { 
        FireButton.onClick.AddListener(() => this.fireBullet() ); 
    }
    

    public override void fireBullet()
    {
        BulletController bulletController1 = BulletService.Instance.activateBulletService(tankModelScript.bulletScriptableObject);
        bulletController1.setBulletFireTransform(playerTankViewScript.BulletFireTransform);
        bulletController1.setPosition();
        bulletController1.FireBullet();
        // Debug.Log("Fired"); 
        noOFBulletShots += 1;

        if(noOFBulletShots == 5)
        { 
            PlayerTankService.Instance.TriggerBulletFireAchivement(BulletFireAchivement.BegginerShooter);
        }
        else if(noOFBulletShots == 10)
        {
            PlayerTankService.Instance.TriggerBulletFireAchivement(BulletFireAchivement.AmateurShooter);
        }
        else if(noOFBulletShots == 20)
        {
            PlayerTankService.Instance.TriggerBulletFireAchivement(BulletFireAchivement.LegendaryShooter);
        }
    }



    
    public override void applyDamage(BulletType bulletType , int damage , BulletView bullet)
    { 
        // Debug.Log("hit by Bullet");
        if(bulletType == BulletType.EnemyBullet)
        {
            bullet.DestroyBullet();
            reduceHealth(damage); 
        }
    }

    public override void reduceHealth(int damage)
    { 
        tankModelScript.Health -= damage;
        Debug.Log("Health Of Tank " + tankModelScript.tankType +" is " + tankModelScript.Health);
        if(tankModelScript.Health <= 0)
        {
            playerDied = true;
            PlayerTankService.Instance.TriggerPlayerDeathEvent();
            playerTankViewScript.destroyTank();
        }
    }

     public override void moveTankForward()
    {
        playerTankViewScript.TankTransform.position += playerTankViewScript.TankTransform.forward * Time.deltaTime * tankModelScript.Speed;
    }


    public override void moveTankBackWard()
    {
        playerTankViewScript.TankTransform.position -= playerTankViewScript.TankTransform.forward * Time.deltaTime * tankModelScript.Speed;
    }


    public override void tankRotation()
    {
        playerTankViewScript.TankTransform.Rotate(0,  RotationJoystick.Horizontal * tankModelScript.RotationSpeed * Time.deltaTime , 0);
    }
}


   

      // BulletController bulletController = new BulletController(bulletModel , bullet.bulletPrefab); 
       
      // BulletController bulletController = bulletServicePool.GetBullet(bulletModel,bulletView);
      // this.bullet = bulletController;
      // return bulletController;