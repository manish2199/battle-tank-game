using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankController : TankController
{
    int wayPointIndex;
    
	public bool isEnemyDies { get; protected set; }

	Transform targetTransform;
    
	public Transform[] EnemyPatrollingWayPoints { get; }
     
	public EnemyTankView enemyTankViewScript { get;}
    

    public EnemyTankModel enemyTankModelScript { get; }

	private Vector3 targetWayPoint;

    public EnemyTankController(EnemyTankModel enemyTankModel , GameObject enemyTankPrefab , Transform positionToSpawn , Transform[] enemyPtrollingWaypoints)
	{
	   enemyTankModelScript = enemyTankModel ;
 
       GameObject temp  = GameObject.Instantiate(enemyTankPrefab,positionToSpawn);
       enemyTankViewScript = temp.GetComponent<EnemyTankView>();

       enemyTankViewScript.enemyTankController = this;
    
	   EnemyPatrollingWayPoints = enemyPtrollingWaypoints;
	}  

	public override void takeDamage(BulletView bulletView)
	{
        if(bulletView.bulletController.bulletModelScript.bulletType == BulletType.PlayerBullet)
        {
			// Debug.Log("hit by player");
            reduceHealth(bulletView.bulletController.bulletModelScript.Damage);
            enemyTankViewScript.destroyBullet(bulletView);
		}

	} 

  	public void reduceHealth(int damage)
	{
	 	enemyTankModelScript.Health -= damage;
        Debug.Log("Health Of Tank is " + enemyTankModelScript.Health);
		if(enemyTankModelScript.Health <= 0 )
		{
			enemyTankViewScript.destroyTank();
			isEnemyDies = true;
		}
	}

	

    public void patrolling()
   {  
		enemyTankViewScript.agent.stoppingDistance = enemyTankModelScript.stoppingDistanceFromObstacle ;
       if(Vector3.Distance(enemyTankViewScript.TankTransform.position,targetWayPoint) < enemyTankModelScript.stoppingDistanceFromObstacle )
	   { 
         IterateWaypointIndex();
		 UpdateDestination(); 
	   }
   }

	public void chaseTheTarget(GameObject targetGameObject)
	{
		enemyTankViewScript.agent.stoppingDistance = enemyTankModelScript.stoppingDistanceFromPlayer;
        enemyTankViewScript.agent.SetDestination(targetGameObject.transform.position);
	}

    public void fireBullet( )
	{ 
       EnemyTankService.Instance.fireBullet(enemyTankModelScript.bulletScriptableObject , enemyTankViewScript.BulletFireTransform);
	}
 
	public void faceTheTarget(Transform targetObject)
    {
        Vector3 direction = (targetObject.position -  enemyTankViewScript.TankTransform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
    	enemyTankViewScript.TankTransform.rotation = Quaternion.Slerp( enemyTankViewScript.TankTransform.rotation,lookRotation,Time.deltaTime*5f);
    }
   

 	public void UpdateDestination()
	{
        targetWayPoint = EnemyPatrollingWayPoints[wayPointIndex].position;
		enemyTankViewScript.agent.SetDestination(targetWayPoint); 
	}

 	public void IterateWaypointIndex()
	{
       wayPointIndex ++;
	   if(wayPointIndex == EnemyPatrollingWayPoints.Length)
	   {
		   wayPointIndex = 0;
	   }
	}





}
