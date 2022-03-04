using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
   public BulletServicePool bulletServicePool; 

   void Start()
   {
      bulletServicePool = GetComponent<BulletServicePool>();
   }

   public BulletController activateBulletService(BulletScriptableObject bullet  )
   {
      BulletModel bulletModel = new BulletModel(bullet);
      BulletView bulletView = bullet.bulletView;

     // BulletView bulletView = bullet.bulletPrefab.GetComponent<BulletView>();
       
      BulletController bulletController = bulletServicePool.GetBullet(bulletModel,bulletView);
      bulletController.EnableBull();

      return bulletController;
   }

   public void returnBulletToPool(BulletController bulletController)
   { 
      bulletServicePool.ReturnItem(bulletController); 
   }

}
