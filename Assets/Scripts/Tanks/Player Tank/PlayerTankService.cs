using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankService : GenericSingleton<PlayerTankService>
{    
    private TankModel tankModel; 
    private PlayerTankController playerTank;

    public bool IsPlayerDied { get; protected set; }
 
    [HideInInspector] public Transform tankTransform;


    [SerializeField]  private Transform tankInstantiatePosition;            // Postion to spwan player tank
    [SerializeField] private TankScriptableObjectList playerTankScriptableObjectList;


    // Input Button and Joysticks
    [SerializeField] private Button fireButton;
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick rotationJoystick;

     
    protected override void Awake()
	{
		base.Awake();
	}

    void Start()
    {
       instantiatePlayerTank(); 
    }

    void Update()
    {
        IsPlayerDied = playerTank.playerDied;
    }


 
    private void instantiatePlayerTank()
    { 
       TankScriptableObject tank = setPlayerTankModel();

       playerTank = new PlayerTankController(tankModel,tank.tankPrefab,fireButton,movementJoystick,rotationJoystick,tankInstantiatePosition);
       
       
       // Set position Transform
       tankTransform = playerTank.playerTankViewScript.TankTransform;
        
    }

    private TankScriptableObject setPlayerTankModel()
    {
       TankScriptableObject tank = getRandomPlayerTankScriptableObject();
        
       tankModel = new TankModel(tank);
       tankModel.bulletScriptableObject.bulletType = BulletType.PlayerBullet;

       return tank;
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
