using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{

   public TankModel(){}


   public TankModel(TankScriptableObject tank)
   {
      Speed =tank.Speed ;
      playerTankType = tank.playerTankType;
      Health = tank.Health;
      RotationSpeed = tank.RotationSpeed;
      bulletScriptableObject = tank.bulletType;
      tankType = tank.tankType;
   }

   public TankType tankType { get; }

   public  BulletScriptableObject  bulletScriptableObject { get; protected set; }

   public PlayerTankType playerTankType { get; }

   public float Speed { get; }

   public float RotationSpeed { get; }
 
   public int Health { get;  set; }   

}



    