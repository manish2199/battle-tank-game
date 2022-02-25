using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
   [HideInInspector]public Transform bulletFireTransform;

   public void activateBulletService(BulletScriptableObject bullet)
   {
      BulletModel bulletModel = new BulletModel(bullet);
       
      BulletView bulletView = bullet.bulletPrefab.GetComponent<BulletView>();
      BulletController bulletController = new BulletController(bulletModel , bulletView , bulletFireTransform );
   }


   // public void HitTheTank(TankType tankType , int bulletDamage)
   // {
   //    if(tankType == TankType.TankEnemy)
   //    {
   //       // call enemy tank service to reduce the health
   //       EnemyTankService.Instance.reduceHealth(bulletDamage);           
   //    }
   //    if(tankType == TankType.TankPlayer)
   //    {
   //       // call player tank service to reduce the health
   //       PlayerTankService.Instance.reduceHealth(bulletDamage);           
   //    }
   // }
   
}
