using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankModel : TankModel
{
   public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject) : base (playerTankScriptableObject)
   {
      playerTankType = playerTankScriptableObject.playerTankType;
      RotationSpeed = playerTankScriptableObject.RotationSpeed;
      Score  = 0;
      IdleAudioClip = playerTankScriptableObject.tankAudio.idleClip;
      DrivingAudioClip = playerTankScriptableObject.tankAudio.drivingClip;
      OrignalePitch = playerTankScriptableObject.tankAudio.OrignalePitch;
      PitchRange = playerTankScriptableObject.tankAudio.PitchRange;
   }

  public float OrignalePitch { get; set;}

  public float PitchRange { get; set;}

  public AudioClip IdleAudioClip { get; }
 
  public AudioClip DrivingAudioClip { get; }

  public int Score { get; set; }

  public PlayerTankType playerTankType { get; }

  public float RotationSpeed { get; }

  public int noOFBulletShots = 0;

  public int TempPointer;

}
