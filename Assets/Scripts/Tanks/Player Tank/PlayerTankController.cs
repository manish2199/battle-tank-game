using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController 
{   
    public TankModel TankM { get;}
    
    public TankView TankV { get;}
    
    public GameObject TankGameObject { get;}

    public PlayerTankController(TankModel tankModel ,GameObject tankPrefab ,Transform pos)
    {
       TankM = tankModel;
         
       GameObject temp  = GameObject.Instantiate(tankPrefab,pos);
       TankV = temp.GetComponent<TankView>();

       TankV.tankType = TankM.tankType;
        
       TankV.TankSpeed = TankM.Speed;
       
       TankV.RotationSpeed = TankM.RotationSpeed;
    }
}
