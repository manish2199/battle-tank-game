using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{     
    private EnemyTankModel enemy1TankModel;
    private EnemyTankController enemy1TankController;
    
    [HideInInspector] public bool enemiesDies;

    [SerializeField] private Transform enemyTankInstantiatePosition;            // Postion to spwan enemy tank
     
    [SerializeField] private EnemyTankScriptableObject enemyTankScriptableObject;

    [SerializeField] Transform[] enemy1WayPoints;                                // Enemy tanks patrolling waypoints

    Transform particleEffectTransform; 
    ParticleSystem particleEffect;
    bool isStartParticle =  true;

  
   void Start()
   {     
        instantiateEnemyTank();
        print(PlayerTankService.Instance.IsPlayerDied);

   }

   void Update()
   {
       if(PlayerTankService.Instance.IsPlayerDied)
       {
           if(enemy1TankController.enemyTankViewScript != null) {enemy1TankController.enemyTankViewScript.destroyTank();}
           EnemiesDeathEffect();
       }
   }

   void EnemiesDeathEffect()
   {
        if(isStartParticle)
        {
          print(isStartParticle);
          isStartParticle = false;
          GameObject.Instantiate(particleEffect,particleEffectTransform.position,Quaternion.identity);
           enemiesDies = true;
        }

        // yield return new WaitForSeconds(1.5f);

        // particleEffect.Stop();
   }

   
    private void instantiateEnemyTank()
    {
        enemy1TankModel = new EnemyTankModel(enemyTankScriptableObject);
        enemy1TankModel.bulletScriptableObject.bulletType = BulletType.EnemyBullet;

        enemy1TankController = new EnemyTankController(enemy1TankModel,enemyTankScriptableObject.tankPrefab,enemyTankInstantiatePosition,enemy1WayPoints);
        particleEffectTransform = enemy1TankController.enemyTankViewScript.TankTransform;
        particleEffect = enemy1TankController.enemyTankModelScript.DeathEffect;
    }


    public void fireBullet( BulletScriptableObject bulletScriptableObject , Transform bulletFireTransform )
    {
        BulletService.Instance.bulletFireTransform = bulletFireTransform;
        BulletService.Instance.activateBulletService(bulletScriptableObject);
    }
}
