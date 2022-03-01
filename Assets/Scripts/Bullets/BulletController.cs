using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    public BulletModel bulletModelScript { get; }

    public BulletView bulletViewScript { get; }

    private Transform bulletFireTransform ;

    public GameObject bulletGameObject;

    public BulletController(BulletModel bulletModel , GameObject bulletPrefab)
    {
       bulletModelScript = bulletModel;

       this.bulletFireTransform = bulletFireTransform; 

       
       bulletGameObject = GameObject.Instantiate(bulletPrefab);
       bulletViewScript = bulletGameObject.GetComponent<BulletView>();

       bulletViewScript.bulletController = this;

    }

    public void setBulletFireTransform(Transform bulletFire)
    {
        bulletFireTransform = bulletFire;
    } 


    public void setPosition()
    {
        bulletGameObject.transform.rotation = bulletFireTransform.rotation;  
        bulletGameObject.transform.position = bulletFireTransform.position;
    }


    public void DestroyBullet()
    {
        bulletViewScript.DestroyBullet();
    }


    public void FireBullet()
    {   
        bulletViewScript.rgb.AddForce(bulletFireTransform.forward * bulletModelScript.BulletSpeed,ForceMode.Impulse);   
    }
}

