using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{ 
   [HideInInspector] public BulletController bulletController;

   public Rigidbody rgb;

   public Transform thisTransform;
  
   public void DestroyBullet()
   {
      Destroy(this.gameObject);
   }

   void OnTriggerEnter(Collider target)
   { 
     IDamagable damagable = target.gameObject.GetComponent<IDamagable>();
     if(damagable != null)
     {
         damagable.TakeDamage(bulletController.bulletModelScript.bulletType , bulletController.bulletModelScript.Damage , this );
     }
     else
     {
       Destroy(this.gameObject); 
     }
   }
}