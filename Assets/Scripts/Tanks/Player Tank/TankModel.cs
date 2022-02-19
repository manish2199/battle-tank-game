using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
   public TankModel(TankScriptableObject tank)
   {
      Speed =tank.Speed ;
      tankType = tank.tankType;
      Damage = tank.Damage ;
      Health = tank.Health;
      RotationSpeed = tank.RotationSpeed;
   }

   // public TankModel(float speed , float rotationSpeed )
   // {
   //    Speed = speed;
   //    RotationSpeed = rotationSpeed;
   // }

   public TankType tankType { get; }

   public float Speed { get; }

   public float RotationSpeed { get; }
 
   public float Damage { get; }   

   public float Health { get; }   

}
