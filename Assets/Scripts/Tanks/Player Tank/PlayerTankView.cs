using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTankView : TankView 
{  
    public AudioSource MovementAudio;

    [SerializeField] private Transform tankTransform;
    public Transform TankTransform   { get { return tankTransform; } }  

    public PlayerTankController playerTankController;   
  
    [SerializeField] private Transform bulletFireTransform;
    public Transform BulletFireTransform { get { return bulletFireTransform;}  }  

    public GameObject HealthBarCanvas;
    public GameObject[] HealthBarImages;

    void OnEnable()
    { 
       PlayerTankService.IncrementScore += increaseScore;
    }

    void OnDisable()
    {
       PlayerTankService.IncrementScore -= increaseScore;
    }

    void increaseScore()
    {
        playerTankController.IncreasePlayerTankScore();
    }

    void Start()
    {
        playerTankController.SetFireButtonFunction(); 
        playerTankController.SetOrignalPitch();
    }

    public void Update()
    {
        playerTankController.tankMovement();      
 
        playerTankController.handleTankRotation(); 
         
        playerTankController.HandleEngineAudio();
    }

    private void LateUpdate()
    {
       playerTankController.SetOrientationOfHealthBar();
    }

    public override void TakeDamage(BulletType bulletType , int damage, BulletView bullet)
    {
        playerTankController.applyDamage(bulletType , damage , bullet );

        // update the health bar
        // playerTankController.UpdateTheHealthBar();
    }
    
    public override void destroyTank()
    {
        Destroy(this.gameObject);
    }
   
}
