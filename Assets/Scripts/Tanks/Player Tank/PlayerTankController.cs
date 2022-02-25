using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerTankController : TankController
{

    public PlayerTankController(TankModel tankModel , GameObject tankPrefab , Button fireButton , Joystick movementJoystick , Joystick rotationJoystick , Transform positionToInstantiate)
    { 
        tankModelScript = tankModel;
 
       GameObject temp  = GameObject.Instantiate(tankPrefab,positionToInstantiate);
       tankViewScript = temp.GetComponent<PlayerTankView>();

       MovementJoystick = movementJoystick;
       RotationJoystick = rotationJoystick;
       this.fireButton = fireButton;

       tankViewScript.playerController = this; 

    } 
    
    public override void takeDamage(BulletView bulletView)
    { 
        if(bulletView.bulletController.bulletModelScript.bulletType == BulletType.EnemyBullet)
        {
            Debug.Log("hit by Enemy");
            reduceHealth(bulletView.bulletController.bulletModelScript.Damage);

            tankViewScript.destroyBullet(bulletView);
        }
    }
}
