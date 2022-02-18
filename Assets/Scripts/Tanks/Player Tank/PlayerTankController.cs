using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController 
{   
    public TankModel TankM { get;}
    
    public TankView TankV { get;}
    
    public PlayerTankController(TankModel tankModel , TankView tankPrefab ,Transform pos)
    {
       TankM = tankModel;
         
       TankV = GameObject.Instantiate<TankView>(tankPrefab,pos);

       TankV.tankSpeed = TankM.Speed;
       
       TankV.rotationSpeed = TankM.RotationSpeed;
    }
}
