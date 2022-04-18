using System;
using UnityEngine;

[CreateAssetMenu (fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObjectList")]
public class PlayerTankScriptableObjectList : ScriptableObject
{
   public PlayerTankScriptableObject[] tankLists;
}

