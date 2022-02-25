using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankView : TankView
{

  public EnemyTankController enemyTankController; 

  [HideInInspector] public NavMeshAgent agent;

  [SerializeField] GameObject tankRenderers;
  
  GameObject target;

  bool canPatrol = true;

  bool canShoot = true;

  bool canChase = false;

  bool isPlayerDied;

  void Start()
  {
	  agent = GetComponent<NavMeshAgent>(); 

    agent.speed = enemyTankController.enemyTankModelScript.Speed;
	 
    enemyTankController.UpdateDestination();
    
    target = GameObject.FindWithTag("Player");
  }

  void Update()
  {
    if(canPatrol == true && canChase == false)
	  {
	    enemyTankController.patrolling();
	  }

    attackingPlayer();
     
  } 

  public override void destroyTank()
  {
    Destroy(this.gameObject);
  }

  void OnTriggerEnter( Collider target)
  {
    BulletView temp1 = target.GetComponent<BulletView>();
    if(temp1 != null)
    {
      print("Bullet hit by player");
      enemyTankController.takeDamage(temp1);   
    }
  }

  void FireBullet()
  {    
    enemyTankController.fireBullet(); 
  }

  public override void destroyBullet(BulletView bullet)
  {
    Destroy(bullet.gameObject);
  }
  

  void startShoot()
  {
     InvokeRepeating("FireBullet",1.5f,1.5f);
     canShoot = false;
  }

  void attackingPlayer()
    {
      float distance = 0;
      if(target != null)
		  {
        distance = Vector3.Distance(target.transform.position,transform.position);
      }
      else if( target == null)
      { 
        destroyTank();  
        return;
      }
         
      if(distance <= enemyTankController.enemyTankModelScript.TargetDetectingRange)
      {
        canChase = true;
	      canPatrol = false;
        enemyTankController.chaseTheTarget(target);

        if(distance <= agent.stoppingDistance)
        {
          enemyTankController.faceTheTarget(target.transform);
          if(canShoot)
          {
              startShoot();
          }
        }
      } 
      else if(distance > enemyTankController.enemyTankModelScript.TargetDetectingRange)
      {
        CancelInvoke();
        canShoot = true;
  	    canChase = false;
        canPatrol = true ;
        enemyTankController.UpdateDestination();
      }
     
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