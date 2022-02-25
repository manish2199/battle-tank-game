using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public BulletModel(BulletScriptableObject bullet)
    {
        BulletSpeed = bullet.bulletSpeed;
        Damage = bullet.damage;
        BulletPrefab = bullet.bulletPrefab;
        bulletType = bullet.bulletType;
    }

    public GameObject BulletPrefab { get; }

    public float BulletSpeed { get ;}

    public int Damage { get; }

    public BulletType bulletType { get; }

}
