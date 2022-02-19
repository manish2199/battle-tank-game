using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController 
{   
    public TankModel tankModelScript { get;}
    
    public TankView tankViewScript { get;}
    
    // public GameObject TankGameObject { get; } 

    public Joystick MovementJoystick { get; }

    public Joystick RotationJoystick { get; }


    public PlayerTankController(TankModel tankModel  , GameObject tankPrefab  ,  Joystick movementJoystick  , Joystick rotationJoystick  ,  Transform pos)
    {
       tankModelScript = tankModel;
 
       GameObject temp  = GameObject.Instantiate(tankPrefab,pos);
       tankViewScript = temp.GetComponent<TankView>();

       MovementJoystick = movementJoystick;
       RotationJoystick = rotationJoystick;

       tankViewScript.playerController = this;
    } 

    public virtual void moveTankForward()
    {
        tankViewScript.TankTransform.position += tankViewScript.TankTransform.forward * Time.deltaTime * tankModelScript.Speed;
    }


    public virtual void moveTankBackWard()
    {
        tankViewScript.TankTransform.position -= tankViewScript.TankTransform.forward * Time.deltaTime * tankModelScript.Speed;
    }



    public void tankRotation()
    {
        tankViewScript.TankTransform.Rotate(0, RotationJoystick.Horizontal * tankModelScript.RotationSpeed * Time.deltaTime , 0);
    }
}
