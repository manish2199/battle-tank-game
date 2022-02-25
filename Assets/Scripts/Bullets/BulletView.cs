using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{ 
   [HideInInspector] public BulletController bulletController;

   [SerializeField] Rigidbody rgb;
   public Rigidbody BulletRigidbody { get { return rgb;  } } 

   void Start()
   {
      bulletController.addForecesToBullet();
   }


   void OnTriggerEnter(Collider target)
   {
     if( target.gameObject.GetComponent<TankView>() == null && target.gameObject.GetComponent<EnemyTankView>() == null )
     {
        Destroy(gameObject);
     }
   }
}