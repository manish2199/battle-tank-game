using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController 
{   
    
    public TankView tankViewScript { get;}
    

    public TankModel tankModelScript { get; }
    
    
    public Joystick MovementJoystick { get; }

    
    public Joystick RotationJoystick { get; }
     

    public Button fireButton { get; } 


    public TankController(){}

    
    public TankController(TankModel tankModel  , GameObject tankPrefab  , Button fireButton ,  Joystick movementJoystick  , Joystick rotationJoystick  ,  Transform pos)
    {
       tankModelScript = tankModel;
 
       GameObject temp  = GameObject.Instantiate(tankPrefab,pos);
       tankViewScript = temp.GetComponent<TankView>();

       MovementJoystick = movementJoystick;
       RotationJoystick = rotationJoystick;
       this.fireButton = fireButton;

       tankViewScript.playerController = this;
    } 


    public virtual void fireBullet()
    {
        if(fireButton != null)
        {
            GameObject bulletPrefab = tankModelScript. bulletScriptableObject.bulletPrefab;
            Transform bulletFireTransform = tankViewScript.BulletFireTransform;
            float speed = tankModelScript.bulletScriptableObject.bulletSpeed;

            GameObject bulletGameObject = GameObject.Instantiate(bulletPrefab,bulletFireTransform.position,bulletFireTransform.transform.rotation);
            bulletGameObject.GetComponent<Rigidbody>().AddForce(bulletFireTransform.forward * speed , ForceMode.Impulse);          
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
