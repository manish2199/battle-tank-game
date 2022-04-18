using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletServicePool : ServicePool<BulletController>
{
    BulletView bulletPrefab;
    BulletModel bulletModel;

    public BulletController GetItem(BulletType bulletType)
    {
        if(pooledItems.Count > 0)
       {
           PoolItem<BulletController> item = pooledItems.Find( I => I.isUsed == false);
           if(item != null && item.Item.bulletModelScript.bulletType == bulletType )  
           { 
              item.isUsed = true;
              return  item.Item; 
           }
       }
       // create new item for pool
       return createNewPooledItem();
    }
    
    public BulletController GetBullet(BulletModel bulletModel , BulletView bulletPrefab)
    {
        this.bulletModel = bulletModel;
        this.bulletPrefab = bulletPrefab;
        return this.GetItem(bulletModel.bulletType);
    }

	protected override BulletController CreateItem()
	{
		BulletController bulletController = new BulletController(bulletModel, bulletPrefab);
        return bulletController;
	}

}
