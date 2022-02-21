using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerTankController : TankController
{

    public PlayerTankController(TankModel tankModel , GameObject tankPrefab , Button fireButton , Joystick movementJoystick , Joystick rotationJoystick , Transform pos) : base (tankModel,tankPrefab,fireButton,movementJoystick,rotationJoystick,pos)
    {} 
    
   public override void fireBullet()
    {
        base.fireBullet();
    }


    public override void moveTankForward()
    {
        base.moveTankForward(); 
    }


    public override void moveTankBackWard()
    {
       base.moveTankBackWard();
    }


    public override void tankRotation()
    {
       base.tankRotation();
    }
}
