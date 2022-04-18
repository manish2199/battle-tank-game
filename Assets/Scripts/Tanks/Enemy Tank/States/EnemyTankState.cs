using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public abstract class EnemyTankState : MonoBehaviour
{
    protected EnemyTankView enemyTankView;

    protected NavMeshAgent AIagent;


    void Awake()
    {
        enemyTankView = GetComponent<EnemyTankView>();
         
        AIagent = GetComponent<NavMeshAgent>(); 
    }

    public virtual void OnStateEnter() { this.enabled = true; }
    public virtual void OnStateExit() { this.enabled = false; }
    
}
