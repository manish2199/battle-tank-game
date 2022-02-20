using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
   public TankModel(TankScriptableObject tank)
   {
      Speed =tank.Speed ;
      tankType = tank.tankType;
      Health = tank.Health;
      RotationSpeed = tank.RotationSpeed;
      bulletScriptableObject = tank.bulletType;
   }

   public  BulletScriptableObject  bulletScriptableObject { get; }

   public TankType tankType { get; }

   public float Speed { get; }

   public float RotationSpeed { get; }
 
   public float Health { get; }   

}
