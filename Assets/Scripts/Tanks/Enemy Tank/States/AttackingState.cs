using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackingState : EnemyTankState
{   
   protected Transform targetTransform;

    bool canChase;

    bool canShoot;

    float stoppingDistanceFromTarget;

    protected EnemyTankController enemyTankController;


    void Update()
    {
        if(targetTransform ==  null )
        {
            enemyTankController.enemyTankViewScript.destroyTank();
            return;
        }

        float distance = Vector3.Distance(targetTransform.position,transform.position);
        
        if(canChase)
        {
           chaseTheTarget();

           if(distance <= AIagent.stoppingDistance)
           {   
               faceTheTarget();
        
               if(canShoot)
               {
                  startShoot();
               }
           }

        }

        if(distance > enemyTankController.enemyTankModelScript.TargetDetectingRange)
        {
           CancelInvoke();
           enemyTankView.SetState(enemyTankView.patrollingState);
        } 
    }

    public void chaseTheTarget()
	{
		setAttackingStoppingDistance();
        AIagent.SetDestination(targetTransform.position);
	}
    
    void setAttackingStoppingDistance()
	{
		AIagent.stoppingDistance = stoppingDistanceFromTarget;
	}

    public void faceTheTarget()
    {
        Vector3 direction = (targetTransform.position -  transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
    	transform.rotation = Quaternion.Slerp( transform.rotation , lookRotation , Time.deltaTime*5f);
    }

    
   void FireBullet()
   {    
      enemyTankController.fireBullet(); 
    }

    void startShoot()
   {
      canShoot = false;
      InvokeRepeating("FireBullet",1f,1f);
    }


    public override void OnStateEnter()
    {
       base.OnStateEnter();

         AIagent.speed = enemyTankView.enemyTankController.enemyTankModelScript.Speed;

       enemyTankController = enemyTankView.enemyTankController;

       targetTransform = enemyTankView.target;

       stoppingDistanceFromTarget = enemyTankController.enemyTankModelScript.stoppingDistanceFromPlayer;      

       canShoot = true;

       canChase = true;
    }

    public override void OnStateExit()
    {
       canChase = false;

       canShoot = false;

       base.OnStateExit();

    }

}
