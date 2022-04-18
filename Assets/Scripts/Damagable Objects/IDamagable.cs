using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public void TakeDamage(BulletType bulletType , int damage , BulletView bulletView );
}
