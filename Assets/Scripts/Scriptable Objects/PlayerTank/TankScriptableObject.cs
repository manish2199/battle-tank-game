using System;
using UnityEngine;

[CreateAssetMenu (fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject 
{

   public PlayerTankType playerTankType;       

   public float RotationSpeed;
   
   public TankType tankType;  
   
   public GameObject tankPrefab;               // enemy can have
   
   public int Health;                        //enemy can have
   
   public float Speed;
   
   public BulletScriptableObject bulletType;   // enemy can have


   // public PlayerTankType PlayerTankType { get; }

   // public float rotationSpeed { get; }
}



