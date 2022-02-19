using System;
using UnityEngine;

[CreateAssetMenu (fileName = "TankScriptableObjet", menuName = " ScriptableObject/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject 
{
   public TankType tankType;
   public GameObject tankPrefab;
   public float Health;
   public float RotationSpeed;
   public float Speed;
   public float Damage;
}



