using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TankModel 
{
   public TankModel(TankScriptableObject tank)
   {
      Speed =tank.Speed ;
      Health = tank.Health;
      bulletScriptableObject = tank.bulletType;
      tankType = tank.tankType;
   }

   public TankType tankType { get; }

   public  BulletScriptableObject  bulletScriptableObject { get; protected set; }

   public float Speed { get; }
 
   public int Health { get;  set; }   

}



    