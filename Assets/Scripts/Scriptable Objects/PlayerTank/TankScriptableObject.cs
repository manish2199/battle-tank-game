using System;
using UnityEngine;

[CreateAssetMenu (fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject 
{
   public PlayerTankType playerTankType;         
   public GameObject tankPrefab;               // enemy can have
   public float Health;                        //enemy can have
   public float RotationSpeed;
   public float Speed;
   public BulletScriptableObject bulletType;   // enemy can have
}



