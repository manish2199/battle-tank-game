using System;
using UnityEngine;

[CreateAssetMenu (fileName = "BulletScriptableObject", menuName = "ScriptableObject/NewBulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject 
{
   public BulletType bulletType;
   public GameObject bulletPrefab;
   public float bulletSpeed; 
   public float damage;
}



