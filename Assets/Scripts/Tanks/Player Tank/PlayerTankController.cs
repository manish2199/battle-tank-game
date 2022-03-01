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
    
     public override void SetFireButtonFunction()
    { 
        FireButton.onClick.AddListener(() => this.fireBullet() ); 
    }
    

    public override void fireBullet()
    {
        // Debug.Log("Fired Bullet by Player");
    
       BulletController bulletController = BulletService.Instance.activateBulletService(tankModelScript.bulletScriptableObject);
        bulletController.setBulletFireTransform(playerTankViewScript.BulletFireTransform);
        bulletController.setPosition();
        bulletController.FireBullet();
    }

    
    public override void applyDamage(BulletType bulletType , int damage , BulletView bullet)
    { 
        Debug.Log("hit by Bullet");
        if(bulletType == BulletType.EnemyBullet)
        {
            bullet.DestroyBullet();
            reduceHealth(damage); 

            // tankViewScript.destroyBullet(bulletView); 
        }
    }

    public override void reduceHealth(int damage)
    { 
        tankModelScript.Health -= damage;
        Debug.Log("Health Of Tank " + tankModelScript.tankType +" is " + tankModelScript.Health);
        if(tankModelScript.Health <= 0)
        {
            playerDied = true;
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
