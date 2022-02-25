using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{

    public BulletModel bulletModelScript { get; }

    public BulletView bulletViewScript { get; }

    private Transform bulletFireTransform ;
    
    public BulletController(BulletModel bulletModel , BulletView bulletView ,Transform positoinToInstantiate)
    {
       bulletModelScript = bulletModel;

       bulletViewScript = GameObject.Instantiate<BulletView>(bulletView, positoinToInstantiate.position , positoinToInstantiate.transform.rotation);
        
       bulletViewScript.bulletController = this;

       bulletFireTransform = positoinToInstantiate;
    }

    public void addForecesToBullet()
    {    
        bulletViewScript.BulletRigidbody.AddForce(bulletFireTransform.forward * bulletModelScript.BulletSpeed,ForceMode.Impulse);   
    }


}

