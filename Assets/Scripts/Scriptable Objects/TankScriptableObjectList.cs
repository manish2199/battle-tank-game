using System;
using UnityEngine;

[CreateAssetMenu (fileName = "TankScriptableObject", menuName = " ScriptableObject/NewTankScriptableObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
   public TankScriptableObject[] tankLists;
}

