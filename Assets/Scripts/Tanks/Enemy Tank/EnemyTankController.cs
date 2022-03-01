using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankController : TankController
{
    
	public bool isEnemyDies { get; protected set; }
    
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

	public override void applyDamage(BulletType bulletType , int damage , BulletView bulletView)
	{
        if(bulletType == BulletType.PlayerBullet)
        {
			bulletView.DestroyBullet();
			Debug.Log("hit by player");
            reduceHealth(damage);
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

	
    public override void fireBullet()
    {			
        BulletController bulletController1 =  BulletService.Instance.activateBulletService(enemyTankModelScript.bulletScriptableObject);
        bulletController1.setBulletFireTransform(enemyTankViewScript.bulletTransform);
        bulletController1.setPosition();
        bulletController1.FireBullet();
	}
	
}


   

    

    

    