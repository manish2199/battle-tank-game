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
      rgb.velocity = Vector3.zero;

      BulletServicePool.Instance.ReturnItem(bulletController);
     
      gameObject.SetActive(false);
   }

   public void EnableBullet()
   {
     gameObject.SetActive(true); 
     print(bulletController.bulletModelScript.bulletType);
   }

   void OnTriggerEnter(Collider target)
   { 
     IDamagable damagable = target.gameObject.GetComponent<IDamagable>();
     if(damagable != null)
     {
        damagable.TakeDamage(bulletController.bulletModelScript.bulletType , bulletController.bulletModelScript.Damage , this );
     }
     if( damagable == null && bulletController.bulletModelScript.bulletType == BulletType.PlayerBullet)
     {
      //   EnemyTankService.Instance.resetEnemyHitCounter();
          BulletService.Instance.InvokeOnPlayerMiss();
     }
     if(damagable == null)
     {
        DestroyBullet(); 
     }
   }
}