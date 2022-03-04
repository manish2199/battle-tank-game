using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    public BulletModel bulletModelScript { get; }

    public BulletView bulletViewScript { get; }

    private Transform bulletFireTransform ;

    // public GameObject bulletGameObject;

    public BulletController(BulletModel bulletModel ,BulletView bulletView)
    {
       bulletModelScript = bulletModel;

       this.bulletFireTransform = bulletFireTransform; 

       
    //    bulletGameObject = GameObject.Instantiate(bulletPrefab);
    //    bulletViewScript = bulletGameObject.GetComponent<BulletView>();
        bulletViewScript = GameObject.Instantiate<BulletView>(bulletView);

       bulletViewScript.bulletController = this;
    }

    public void setBulletFireTransform(Transform bulletFire)
    {
        bulletFireTransform = bulletFire;
    } 

    public void setPosition()
    {
        bulletViewScript.thisTransform.rotation = bulletFireTransform.rotation;  
        bulletViewScript.thisTransform.position = bulletFireTransform.position;
    }

    public void EnableBull()
    {
        bulletViewScript.EnableBullet();
    }


    public void DestroyBullet()
    {
        bulletViewScript.DestroyBullet();
    }

    public void FireBullet()
    {    
        // setPosition();
        bulletViewScript.rgb.AddForce(bulletFireTransform.forward * bulletModelScript.BulletSpeed,ForceMode.Impulse);   
    }
}

