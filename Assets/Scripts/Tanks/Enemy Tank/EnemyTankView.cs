using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankView :  TankView 
{
  [SerializeField] BoxCollider collider;

   [SerializeField] private Transform tankTransform;
   public Transform TankTransform   { get { return tankTransform; } }  

  public EnemyTankController enemyTankController; 

  [SerializeField] GameObject tankRenderers;  

  [HideInInspector]public Transform target;

  [SerializeField] private Transform enemyBulletFire;  
  public Transform bulletTransform { get; protected set; }

  
  private EnemyTankState currentState;
  public PatrollingState patrollingState;
  public AttackingState attackingState;

  private void OnEnable()
  {
      PlayerTankService.PlayerDeath += StartEnemyDeathCoroutine;
  }

  private void OnDisable()
  {
      PlayerTankService.PlayerDeath -= StartEnemyDeathCoroutine;
  }

  void Start()
  { 
    target = PlayerTankService.Instance.tankTransform;

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

  public void StartEnemyDeathCoroutine()
  {
    StartCoroutine(EnemyDeath());
  }


  IEnumerator EnemyDeath()
  { 
    tankRenderers.SetActive(false);
    collider.enabled = false;
    GameObject.Instantiate(enemyTankController.enemyTankModelScript.DeathEffect,transform.position,Quaternion.identity);

    yield return new WaitForSeconds(1.5f);

    destroyTank();
  
  }


  public override void TakeDamage(BulletType bulletType , int damage , BulletView bulletView)
  {
    enemyTankController.applyDamage(bulletType , damage , bulletView );
  }  


}
   
   




