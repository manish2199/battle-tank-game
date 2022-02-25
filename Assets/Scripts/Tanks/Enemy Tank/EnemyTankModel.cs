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
     
      Speed = enemyTank.Speed;
      
      TargetDetectingRange = enemyTank.targetDetectingRange;

      stoppingDistanceFromPlayer = enemyTank.stoppingDistanceFromPlayer;

      stoppingDistanceFromObstacle = enemyTank.stoppingDistanceFromObstacle;

      DeathEffect  = enemyTank.deathEffect;
      
    }
   
   public ParticleSystem DeathEffect { get; } 

   public float stoppingDistanceFromObstacle { get; }
   
   public float stoppingDistanceFromPlayer { get; }
 
   public float Speed { get; }

   public float TargetDetectingRange { get; }
   
   public TankType tankType { get; }

}
