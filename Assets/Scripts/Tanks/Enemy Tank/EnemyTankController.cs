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

	Camera camera1;

   public EnemyTankController(EnemyTankModel enemyTankModel , GameObject enemyTankPrefab , Transform positionToSpawn , Transform[] enemyPtrollingWaypoints, Camera camera)
	{
	   enemyTankModelScript = enemyTankModel ;
 
       GameObject temp  = GameObject.Instantiate(enemyTankPrefab,positionToSpawn);
       enemyTankViewScript = temp.GetComponent<EnemyTankView>();

       enemyTankViewScript.enemyTankController = this;
    
	   EnemyPatrollingWayPoints = enemyPtrollingWaypoints;
	   enemyTankModelScript.UpdateSpeedSeconds = 0.5f;
       this.camera1 = camera;
	}  

	public override void applyDamage(BulletType bulletType , int damage , BulletView bulletView)
	{
        if(bulletType == BulletType.PlayerBullet)
        {
			bulletView.bulletController.DestroyBullet();
			EnemyTankService.Instance.InvokeOnEnemeyHit();
            reduceHealth(damage);
		}
	} 

  	public void reduceHealth(int damage)
	{
		if( enemyTankModelScript.Health > 0)
		{
	 	    enemyTankModelScript.Health -= damage;
		    float currenHealth = enemyTankModelScript.Health;
            // Debug.Log("Health Of Tank is " + enemyTankModelScript.Health);
            enemyTankViewScript.StartCoroutineHealth(currenHealth);
		}
		if(enemyTankModelScript.Health <= 0 )
		{
			enemyTankViewScript.StartEnemyDeathCoroutine();
			PlayerTankService.Instance.TriggerIncrementScoreEvent(); 
		}
	}


	public IEnumerator UpdateEnemyHealthBar(float currenHealth)
	{
	   float temp = enemyTankViewScript.healthForegroundImage.fillAmount;

	   float tempHealth = currenHealth/100;
 	   float elapsed = 0f;
       
	    while(elapsed < enemyTankModelScript.UpdateSpeedSeconds)
	    {
		   elapsed += Time.deltaTime;
		   enemyTankViewScript.healthForegroundImage.fillAmount = Mathf.Lerp(temp , tempHealth, ( elapsed / enemyTankModelScript.UpdateSpeedSeconds));
    	   yield return null;
	    }
	    enemyTankViewScript.healthForegroundImage.fillAmount = tempHealth;

	}

	public void SetOrientationOfHealthBar()
    { 
        enemyTankViewScript.HealthBarCanvas.transform.LookAt(camera1.transform);
        enemyTankViewScript.HealthBarCanvas.transform.Rotate(0,180,0);
    }

	
    public override void fireBullet()
    {			
        BulletController bulletController1 =  BulletService.Instance.activateBulletService(enemyTankModelScript.bulletScriptableObject);
        bulletController1.setBulletFireTransform(enemyTankViewScript.bulletTransform);
        bulletController1.setPosition();
        bulletController1.FireBullet();
	}
	
}


   

    

    

    