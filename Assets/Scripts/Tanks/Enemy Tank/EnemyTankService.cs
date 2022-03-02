using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{     

    private EnemyTankModel enemy1TankModel;
    private EnemyTankController enemy1TankController;
    
    [SerializeField] private Transform enemyTankInstantiatePosition;            // Postion to spwan enemy tank
     
    [SerializeField] private EnemyTankScriptableObject enemyTankScriptableObject;

    [SerializeField] Transform[] enemy1WayPoints;                                // Enemy tanks patrolling waypoints

    public static int EnemyHitCounter = 0 ;

    public void IncreaseEnemyHitCounter()
    {
       EnemyHitCounter++;
       if(EnemyHitCounter == 3)
       {
         PlayerTankService.Instance.TriggerBulletHitAchievement(ContinuousBulletHit.BronzeInWithoutMiss);
       }
       else if( EnemyHitCounter == 5)
       {
          PlayerTankService.Instance.TriggerBulletHitAchievement(ContinuousBulletHit.SilverINWithoutMiss);
       }
       else if( EnemyHitCounter == 7 )
       {   
          PlayerTankService.Instance.TriggerBulletHitAchievement(ContinuousBulletHit.GoldInWithoutMiss);
       }
    }

    public void resetEnemyHitCounter()
   {
      EnemyHitCounter = 0; 
   }


   void Start()
   {     
        instantiateEnemyTank();
   }

   
    private void instantiateEnemyTank()
    {
        enemy1TankModel = new EnemyTankModel(enemyTankScriptableObject);
    
        enemy1TankController = new EnemyTankController(enemy1TankModel,enemyTankScriptableObject.tankPrefab,enemyTankInstantiatePosition,enemy1WayPoints);  
    }
}
