using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankController : TankController
{
    int wayPointIndex;
    
	public Transform[] EnemyPatrollingWayPoints { get; }
     
	 public EnemyTankView enemyTankViewScript { get;}
    

    public EnemyTankModel enemyTankModelScript { get; }


    public EnemyTankController(EnemyTankModel enemyTankModel , GameObject enemyTankPrefab , Transform positionToSpawn , Transform[] enemyPtrollingWaypoints)
	{
	   enemyTankModelScript = enemyTankModel ;
 
       GameObject temp  = GameObject.Instantiate(enemyTankPrefab,positionToSpawn);
       enemyTankViewScript = temp.GetComponent<EnemyTankView>();

       enemyTankViewScript.enemyTankController = this;
       EnemyPatrollingWayPoints = enemyPtrollingWaypoints;
	}  
   

 	public void UpdateDestination()
	{
        enemyTankViewScript.targetWayPoint = EnemyPatrollingWayPoints[wayPointIndex].position;
		enemyTankViewScript.agent.SetDestination(enemyTankViewScript.targetWayPoint);
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
