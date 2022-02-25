using System;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/NewEnemyTankScriptableObject")]
public class EnemyTankScriptableObject : TankScriptableObject
{ 
    public float targetDetectingRange;

    public float stoppingDistanceFromPlayer ;

    public float stoppingDistanceFromObstacle ;

    public ParticleSystem deathEffect ; 
}
