using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public abstract class TankView : MonoBehaviour , IDamagable
{
    public TankController playerController;
    
   
    public abstract void destroyTank();

    public virtual void TakeDamage(BulletType bulletType , int damage , BulletView bulletView){}
  
}
