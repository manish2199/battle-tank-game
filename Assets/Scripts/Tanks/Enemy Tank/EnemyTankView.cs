using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankView :  TankView , IDamagable
{
  public EnemyTankController enemyTankController; 

  [SerializeField] GameObject tankRenderers;  

  [HideInInspector]public GameObject target;

  [SerializeField] private Transform enemyBulletFire;  
  public Transform bulletTransform { get; protected set; }

  bool isPlayerDied;

  private EnemyTankState currentState;


  public PatrollingState patrollingState;
  public AttackingState attackingState;

  void Start()
  { 
    target = GameObject.FindWithTag("Player");
    print(target.name);

    bulletTransform = enemyBulletFire;

    GetComponent<NavMeshAgent>().speed = enemyTankController.enemyTankModelScript.Speed;

    SetState(patrollingState);
  }

  public void SetState(EnemyTankState state)
    {
      if(currentState != null)
      {   
		      currentState.OnStateExit();
		  }
      currentState = state;
       
      currentState.OnStateEnter();
	}

  public override void destroyTank()
  {
    Destroy(this.gameObject);
  }


  public void TakeDamage(BulletType bulletType , int damage , BulletView bulletView)
  {
    enemyTankController.applyDamage(bulletType , damage , bulletView );
  }  
    
}
   
   


// void OnTriggerEnter( Collider target)
  // {
  //   TankView temp =  target.gameObject.GetComponent<TankView>();
  //   if( temp != null && temp.playerController.tankModelScript.tankType == TankType.TankPlayer)
  //  	{
  //       InvokeRepeating("FireBullet",1.5f,1.5f);
  //   }
  //   
  // } 



// void OnTriggerExit(Collider other)
  // {
  //    TankView temp =  other.gameObject.GetComponent<TankView>();
  //    if( temp != null && temp.playerController.tankModelScript.tankType == TankType.TankPlayer)
	// 	{
	//        if(canChase && !canPatrol)
	//        {
	// 	        enemyTankController.UpdateDestination();
  //           canPatrol = true;
	// 	        canChase = false;
	// 	        CancelInvoke();
  //      }
	// 	}
  // }



// void OnTriggerStay( Collider target)
  // {
	//   TankView temp =  target.gameObject.GetComponent<TankView>();
  //   if( temp != null && temp.playerController.tankModelScript.tankType == TankType.TankPlayer)
  //  	{
	//     canChase = true;
	//     canPatrol = false;
	// 	  enemyTankController.chaseTheTarget(target.gameObject);
      
  //     if(Vector3.Distance(target.gameObject.transform.position,transform.position) <= sphereCollider.radius)
  //     {
  //       canShoot = true;
	// 	    enemyTankController.faceTheTarget(target.gameObject.transform);
	// 	  }      
  //   }
  // }