using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TankController 
{   
    public bool playerDied { get; protected set; }
    
    public TankView tankViewScript { get;  protected set; }
    

    public TankModel tankModelScript { get; protected set; }
    
    
    public Joystick MovementJoystick { get; protected set; }

    
    public Joystick RotationJoystick { get; protected set; }
     

    public Button fireButton { get; protected  set; } 
    
    
    public TankController(){}

    
    public TankController(TankModel tankModel  , GameObject tankPrefab  , Button fireButton ,  Joystick movementJoystick  , Joystick rotationJoystick  ,  Transform positionToInstantiate )
    {}

    public abstract void takeDamage(BulletView bulletView);


    public virtual void reduceHealth(int damage)
    { 
        tankModelScript.Health -= damage;
        Debug.Log("Health Of Tank " + tankModelScript.tankType +" is " + tankModelScript.Health);
        if(tankModelScript.Health <= 0)
        {
            playerDied = true;
            tankViewScript.destroyTank();
        }
    }


    public virtual void moveTankForward()
    {
        tankViewScript.TankTransform.position += tankViewScript.TankTransform.forward * Time.deltaTime * tankModelScript.Speed;
    }


    public virtual void moveTankBackWard()
    {
        tankViewScript.TankTransform.position -= tankViewScript.TankTransform.forward * Time.deltaTime * tankModelScript.Speed;
    }


    public virtual void tankRotation()
    {
        tankViewScript.TankTransform.Rotate(0, RotationJoystick.Horizontal * tankModelScript.RotationSpeed * Time.deltaTime , 0);
    }

}
