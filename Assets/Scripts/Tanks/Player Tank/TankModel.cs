using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
   public TankModel(float speed , float rotationSpeed)
    {
       Speed = speed;
       RotationSpeed = rotationSpeed;
    }

    public float Speed { get; }

    public float RotationSpeed { get; }
}
