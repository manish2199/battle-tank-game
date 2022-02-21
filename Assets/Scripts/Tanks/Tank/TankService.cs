using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : GenericSingleton<TankService>
{    
    // Player Tank
    [Header("PlayerTank Settings")]
    private TankModel tankModel; 
    private PlayerTankController playerTank;
    [HideInInspector] public Transform tankTransform;
    [SerializeField]  private Transform tankInstantiatePosition;            // Postion to spwan player tank
    [SerializeField] private TankScriptableObjectList playerTankScriptableObjectList;


    // Input Button and Joysticks
    [SerializeField] private Button fireButton;
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick rotationJoystick;


//   [Header("Shield Settings")]
    [Header("EnemyTank Settings")]
    // Enemy Tank
    private EnemyTankModel enemyTankModel;
    private EnemyTankController enemyTankController;
    [SerializeField] private Transform enemyTankInstantiatePosition;            // Postion to spwan enemy tank
     
    [SerializeField] private EnemyTankScriptableObject enemyTankScriptableObject;

    // Enemy tanks patrolling waypoints
    [SerializeField] Transform[] enemy1WayPoints;

     
    protected override void Awake()
	{
		base.Awake();
	}

    void Start()
    {
      
       instantiatePlayerTank(); 

       instantiateEnemyTank();

    }


    private void instantiateEnemyTank()
    {
        enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
    
    //    (EnemyTankModel enemyTankModel , GameObject enemyTankPrefab , Transform positionToSpawn , Transform[] enemyPtrollingWaypoints)

        enemyTankController = new EnemyTankController(enemyTankModel,enemyTankScriptableObject.tankPrefab,enemyTankInstantiatePosition,enemy1WayPoints);
    }


 
    private void instantiatePlayerTank()
    {

       TankScriptableObject tank = getRandomPlayerTankScriptableObject();
        
       tankModel = new TankModel(tank);
       playerTank = new PlayerTankController(tankModel,tank.tankPrefab,fireButton,movementJoystick,rotationJoystick,tankInstantiatePosition);
       tankTransform = playerTank.tankViewScript.TankTransform;
    }

    private TankScriptableObject getRandomPlayerTankScriptableObject()
    {
        int max =(playerTankScriptableObjectList.tankLists.Length - 1);
        TankScriptableObject tank = playerTankScriptableObjectList.tankLists[getRandomNumber(0,max)];  
        // TankScriptableObject tank = tankScriptableObjectList.tankLists[1];  
       return tank;
    }


    private int getRandomNumber(int max , int min)
    {
        return Random.Range(max,min);    
    }


}
