using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TankController 
{   
    public bool playerDied { get; protected set; }

    public TankModel tankModelScript { get; protected set; }


    public TankController(){}
    

    public abstract void applyDamage(BulletType bulletType , int damage , BulletView bulletView );

   
    public abstract void fireBullet();

   
    public virtual void reduceHealth(int damage){}


    public virtual void SetFireButtonFunction(){}


    public virtual void moveTankForward(){}


    public virtual void moveTankBackWard(){}


    public virtual void tankRotation(){}

}
