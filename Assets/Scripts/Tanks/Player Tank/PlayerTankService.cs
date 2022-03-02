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


    private TankModel tankModel; 
    private PlayerTankController playerTank;
 
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
