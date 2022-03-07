using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrollingState : EnemyTankState
{  
   protected EnemyTankController enemyTankController;

   protected Transform targetTransform;
    
    Transform[] EnemyPatrollingWayPoints;

    int wayPointIndex;
 
    bool canPatrol;

    float stoppingDistance;

    private Vector3 targetWayPoint;

    float enemyDetectionRange;

    

    void Update()
    {
       if(canPatrol)
       {
           patrolling();
       }   
        

       if(isEnemyDetected())
       {
            enemyTankView.SetState(enemyTankView.attackingState);
       }
    
    }


    bool isEnemyDetected()
    {  
        float distance = 0;
        if(targetTransform != null)
        {
           distance = Vector3.Distance(targetTransform.position,this.transform.position);
        }
        if(distance <= enemyDetectionRange)
        {
            return true;
        } 
        else
        {
        return false;
        }
    }

    void patrolling()
    {
        setPatrollingStoppingDistance();
        if(Vector3.Distance(transform.position,targetWayPoint) < stoppingDistance )
	   { 
          IterateWaypointIndex();
		  UpdateDestination(); 
	    }
    }

    public void setPatrollingStoppingDistance()
   {
       AIagent.stoppingDistance = stoppingDistance ;
   }


    public void UpdateDestination()
	{
        targetWayPoint = EnemyPatrollingWayPoints[wayPointIndex].position;
		AIagent.SetDestination(targetWayPoint); 
	}

 	public void IterateWaypointIndex()
	{
       wayPointIndex ++;
	   if(wayPointIndex == EnemyPatrollingWayPoints.Length)
	   {
		   wayPointIndex = 0;
	   }
	}
      
    public override void  OnStateEnter() 
    {
        base.OnStateEnter();
        
        canPatrol = true;

        AIagent.speed = enemyTankView.enemyTankController.enemyTankModelScript.Speed;
        
        EnemyPatrollingWayPoints = enemyTankView.enemyTankController.EnemyPatrollingWayPoints;
        
        targetTransform = enemyTankView.target;

        enemyTankController = enemyTankView.enemyTankController;

        enemyDetectionRange = enemyTankController.enemyTankModelScript.TargetDetectingRange;
        
        stoppingDistance =  enemyTankController.enemyTankModelScript.stoppingDistanceFromObstacle;
        
        UpdateDestination();
    }

    
    public override void OnStateExit()
    {
        canPatrol = false;

         AIagent.speed = 0f;

        base.OnStateExit();
    }

}

