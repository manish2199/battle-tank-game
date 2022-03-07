using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class PlayerTankService : GenericSingleton<PlayerTankService>
{   
    public static event Action PlayerDeath;

    public static event Action<BulletFireAchivement> BullFireAchv;
    public static event Action<ContinuousBulletHit> BulletHitAchv;
    public static event Action IncrementScore;
    public static event Action<int> UpdateScoreUIText;


    [SerializeReference]private PlayerTankModel tankModel; 
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
        PlayerDeath?.Invoke();
    }

    public void TriggerBulletFireAchivement(BulletFireAchivement achivement)
    {
        BullFireAchv?.Invoke(achivement);
    }

    public void TriggerBulletHitAchievement(ContinuousBulletHit achivement)
    {
        BulletHitAchv?.Invoke(achivement);
    }


    private void instantiatePlayerTank()
    { 
       TankScriptableObject tank = setPlayerTankModel(); 

       playerTank = new PlayerTankController(tankModel,tank.tankPrefab,fireButton,movementJoystick,rotationJoystick,tankInstantiatePosition,camera);
       
       // Set position Transform
       this.tankTransform = playerTank.playerTankViewScript.TankTransform;
       if(tankTransform == null)
       {
           print("TankTransform is null");
       }
       else
       {
           print("TRANSFORM" + tankTransform.position);
           print("TankTransform is not null");
       }
        
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


public enum BulletFireAchivement
{
    BegginerShooter,
    AmateurShooter,
    LegendaryShooter
}



public enum ContinuousBulletHit
{
    BronzeInWithoutMiss,
    SilverINWithoutMiss,
    GoldInWithoutMiss
}
