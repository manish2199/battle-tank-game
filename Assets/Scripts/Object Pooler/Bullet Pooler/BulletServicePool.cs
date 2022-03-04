using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletServicePool : ServicePool<BulletController>
{
    BulletView bulletPrefab;
    BulletModel bulletModel;
    
    public BulletController GetBullet(BulletModel bulletModel , BulletView bulletPrefab)
    {
        this.bulletModel = bulletModel;
        this.bulletPrefab = bulletPrefab;
        return GetItem();
    }

	protected override BulletController CreateItem()
	{
		BulletController bulletController = new BulletController(bulletModel, bulletPrefab);
        return bulletController;
	}

}
