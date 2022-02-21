using System;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/NewEnemyTankScriptableObject")]
public class EnemyTankScriptableObject : TankScriptableObject
{ 
    public TankType tankType;
    public float targetDetectingRange;

}
