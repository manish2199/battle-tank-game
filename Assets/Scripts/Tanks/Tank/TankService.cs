using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : GenericSingleton<TankService>
{    
    
    [SerializeField] TankScriptableObjectList tankScriptableObjectList;
    
    // Postion to spwan tank
    [SerializeField]  Transform tankInstantiatePosition;


    // Input Button and Joysticks
    [SerializeField] Button fireButton;
    [SerializeField] Joystick movementJoystick;
    [SerializeField] Joystick rotationJoystick;
    
    TankModel tankModel; 
    
    TankController tankController;

    PlayerTank  playerTank;

    [HideInInspector] public Transform tankTransform;

    protected override void Awake()
	{
		base.Awake();
	}

    void Start()
    {
      
       instantiateTank(); 

    }
 
    void instantiateTank()
    {

       TankScriptableObject tank = getRandomTank();
        
       tankModel = new TankModel(tank);
       tankController = new TankController(tankModel,tank.tankPrefab,fireButton,movementJoystick,rotationJoystick,tankInstantiatePosition);
       tankTransform = tankController.tankViewScript.TankTransform;

    }

    TankScriptableObject getRandomTank()
    {
        int max =(tankScriptableObjectList.tankLists.Length - 1);
        // TankScriptableObject tank = tankScriptableObjectList.tankLists[getRandomNumber(0,max)]; 
        TankScriptableObject tank = tankScriptableObjectList.tankLists[2]; 
       return tank;
    }


    int getRandomNumber(int max , int min)
    {
        return Random.Range(max,min);    
    }


}
