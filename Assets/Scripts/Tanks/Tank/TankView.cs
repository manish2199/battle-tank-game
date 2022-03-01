using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public abstract class TankView : MonoBehaviour 
{
    public TankController playerController;
    
    [SerializeField] private Transform tankTransform;
    public Transform TankTransform   { get { return tankTransform;} }  


    public abstract void destroyTank();
    
    public virtual void tankMovement() {}
   
    public virtual void handleTankRotation(){}
}
