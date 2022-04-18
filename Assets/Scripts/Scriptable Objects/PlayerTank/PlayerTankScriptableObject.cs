using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu (fileName = "TankScriptableObject", menuName = "ScriptableObject/NewPlayerTankScriptableObject")]
public class PlayerTankScriptableObject : TankScriptableObject 
{
   public PlayerTankType playerTankType;       

   public float RotationSpeed;

   [SerializeField] public TankAudio tankAudio;
}




