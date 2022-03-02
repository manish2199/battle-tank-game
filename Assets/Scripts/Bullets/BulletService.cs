using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
   public BulletController activateBulletService(BulletScriptableObject bullet  )
   {
      BulletModel bulletModel = new BulletModel(bullet);

      BulletView bulletView = bullet.bulletPrefab.GetComponent<BulletView>();

      BulletController bulletController = new BulletController(bulletModel , bullet.bulletPrefab);
       
      return bulletController;
   }

}
