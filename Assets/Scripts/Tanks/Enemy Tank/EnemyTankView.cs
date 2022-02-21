using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class EnemyTankView : TankView
{
  public EnemyTankController enemyTankController;

  [HideInInspector] public NavMeshAgent agent;

  [HideInInspector] public Vector3 targetWayPoint;

  void Start()
  {
	agent = GetComponent<NavMeshAgent>(); 
	enemyTankController.UpdateDestination();
  }

  void Update()
  {
    if(Vector3.Distance(transform.position,targetWayPoint) < 1 )
	{
        enemyTankController.IterateWaypointIndex();
		enemyTankController.UpdateDestination();
	}
  }

}
