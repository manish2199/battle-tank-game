using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;


public class EnemyTankView :  TankView 
{
  public EnemyTankController enemyTankController; 
  
  public Transform TankTransform   { get { return tankTransform; } }  
  
  public Transform bulletTransform { get; protected set; }
  
  [HideInInspector]public Transform target;
  
  
  [SerializeField] BoxCollider collider;

  [SerializeField] private Transform tankTransform;
  

  [SerializeField] GameObject tankRenderers;  

  [SerializeField] private Transform enemyBulletFire;  

  public GameObject HealthBarCanvas;

  public Image healthForegroundImage;

  private EnemyTankState currentState;
  public PatrollingState patrollingState;
  public AttackingState attackingState;

  private void OnEnable()
  {
      PlayerTankService.OnPlayerDeath += StartEnemyDeathCoroutine;
  }

  private void OnDisable()
  {
      PlayerTankService.OnPlayerDeath -= StartEnemyDeathCoroutine;
  }

  void Start()
  { 
    target = PlayerTankService.Instance.tankTransform;

    bulletTransform = enemyBulletFire;

    GetComponent<NavMeshAgent>().speed = enemyTankController.enemyTankModelScript.Speed;

    SetState(patrollingState);
  }

  private void LateUpdate()
  {
     enemyTankController.SetOrientationOfHealthBar();
  }


  public void StartCoroutineHealth(float health)
  {
    StartCoroutine(enemyTankController.UpdateEnemyHealthBar(health));
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
   
   




