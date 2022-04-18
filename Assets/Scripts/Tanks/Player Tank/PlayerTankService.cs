using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class PlayerTankService : GenericSingleton<PlayerTankService>
{   
    public static event Action OnPlayerDeath;

    public static event Action OnBulletFire;

    // public static event Action<ContinuousBulletHit> BulletHitAchv; 
    public static event Action IncrementScore;
    public static event Action<int> UpdateScoreUIText;


    private PlayerTankModel tankModel; 
    private PlayerTankController playerTank;
    [HideInInspector] public Transform tankTransform;

    [SerializeField] Camera camera ;

    [SerializeField]  private Transform tankInstantiatePosition;            // Postion to spwan player tank
    [SerializeField] private PlayerTankScriptableObjectList playerTankScriptableObjectList;


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


    public void TriggerIncrementScoreEvent()
    {
        IncrementScore?.Invoke();
    }

    public void TriggerUpdateScoreEvent(int score)
    {
        UpdateScoreUIText?.Invoke(score);
    }


    public void TriggerPlayerDeathEvent()
    {
        OnPlayerDeath?.Invoke();
    }

    public void InvokeBulletFireEvent()
    {
        OnBulletFire?.Invoke();
    }

    // public void TriggerBulletHitAchievement(ContinuousBulletHit achivement)
    // {
        // BulletHitAchv?.Invoke(achivement);
    // }


    private void instantiatePlayerTank()
    { 
       TankScriptableObject tank = setPlayerTankModel(); 

       playerTank = new PlayerTankController(tankModel,tank.tankPrefab,fireButton,movementJoystick,rotationJoystick,tankInstantiatePosition,camera);
       
       // Set position Transform
       this.tankTransform = playerTank.playerTankViewScript.TankTransform;
    }

    private TankScriptableObject setPlayerTankModel()
    {
       PlayerTankScriptableObject tank = getRandomPlayerTankScriptableObject();
        
       tankModel = new PlayerTankModel(tank);
       tankModel.bulletScriptableObject.bulletType = BulletType.PlayerBullet;

       return tank;
    }

    private PlayerTankScriptableObject getRandomPlayerTankScriptableObject()
    {
        int max =(playerTankScriptableObjectList.tankLists.Length - 1);
        PlayerTankScriptableObject tank = playerTankScriptableObjectList.tankLists[getRandomNumber(0,max)];  
       return tank;
    }


    private int getRandomNumber(int max , int min)
    {
        return Random.Range(max,min);    
    }
}
