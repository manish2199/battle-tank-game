using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel : TankModel
{

    public EnemyTankModel(EnemyTankScriptableObject enemyTank)
    {
      tankType = enemyTank.tankType;
      Health = enemyTank.Health;
      bulletScriptableObject = enemyTank.bulletType;
    }

   public float TargetDetectingRange { get; }
   
   public TankType tankType { get; }

}
