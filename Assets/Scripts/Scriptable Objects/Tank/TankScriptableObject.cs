using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{ 
    public TankType tankType;    

   public GameObject tankPrefab;               // enemy can have
   
   public int Health;                        //enemy can have
   
   public float Speed;
   
   public BulletScriptableObject bulletType;   // enemy can have\
  
}


[Serializable]
public class TankAudio
{
   public AudioClip idleClip;
   public AudioClip drivingClip;
   public float PitchRange;
   public float OrignalePitch;
}
