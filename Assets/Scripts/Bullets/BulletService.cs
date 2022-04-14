using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
   public BulletServicePool BulletServicePool; 
   
   public static event Action OnPlayerMissShot;

   public void InvokeOnPlayerMiss()
   {
     OnPlayerMissShot?.Invoke();
   }

   void Start()
   {
      BulletServicePool = GetComponent<BulletServicePool>();
   }

   public BulletController activateBulletService(BulletScriptableObject bullet  )
   {
         BulletController  bulletController = null;
      
         BulletModel bulletModel = new BulletModel(bullet);
         BulletView bulletView = bullet.bulletView;
         bulletController = BulletServicePool.GetBullet(bulletModel,bulletView);
         bulletController.EnableBull();
      
      return bulletController; 
   }

   public void returnBulletToPool(BulletController bulletController)
   { 
      BulletServicePool.ReturnItem(bulletController); 
   }

}
