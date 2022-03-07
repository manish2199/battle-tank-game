using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerTankController : TankController 
{     
    public Button FireButton { get; set;  }  
     
    public Joystick MovementJoystick { get; set; }

    public Joystick RotationJoystick { get; set; } 
    
    public  PlayerTankView playerTankViewScript;

    public PlayerTankModel playerTankModelScript;

    

    private Camera camera;

    public PlayerTankController(PlayerTankModel TankModel , GameObject tankPrefab , Button fireButton , Joystick movementJoystick , Joystick rotationJoystick , Transform positionToInstantiate, Camera camera)
    { 
       playerTankModelScript = TankModel;
       this.camera = camera;  
      
       GameObject temp  = GameObject.Instantiate(tankPrefab,positionToInstantiate);
       playerTankViewScript = temp.GetComponent<PlayerTankView>();

       MovementJoystick = movementJoystick ;
       RotationJoystick = rotationJoystick;
       FireButton = fireButton;

       playerTankViewScript.playerTankController = this; 

       playerTankModelScript.TempPointer = playerTankViewScript.HealthBarImages.Length - 1 ;
    } 

    
    public void IncreasePlayerTankScore()
    {
        playerTankModelScript.Score ++;
        PlayerTankService.Instance.TriggerUpdateScoreEvent(playerTankModelScript.Score);
    }
     
    public override void SetFireButtonFunction()
    { 
        FireButton.onClick.AddListener(() => this.fireBullet() ); 
    }
    

    public override void fireBullet()
    {
        BulletController bulletController1 = BulletService.Instance.activateBulletService( playerTankModelScript.bulletScriptableObject);
        bulletController1.setBulletFireTransform(playerTankViewScript.BulletFireTransform);
        bulletController1.setPosition();
        bulletController1.FireBullet();
        // Debug.Log("Fired"); 
        playerTankModelScript.noOFBulletShots += 1;

        if(playerTankModelScript.noOFBulletShots == 5)
        { 
            PlayerTankService.Instance.TriggerBulletFireAchivement(BulletFireAchivement.BegginerShooter);
        }
        else if(playerTankModelScript.noOFBulletShots == 10)
        {
            PlayerTankService.Instance.TriggerBulletFireAchivement(BulletFireAchivement.AmateurShooter);
        }
        else if(playerTankModelScript.noOFBulletShots == 20)
        {
            PlayerTankService.Instance.TriggerBulletFireAchivement(BulletFireAchivement.LegendaryShooter);
        }
    }


    public void SetOrignalPitch()
    {
        playerTankModelScript.OrignalePitch = playerTankViewScript.MovementAudio.pitch;
    } 


    public void HandleEngineAudio()
    {
        if(Mathf.Abs(MovementJoystick.Vertical) <= 0.2f  && Mathf.Abs(RotationJoystick.Horizontal) <= 0.2f  )
        {
            if(playerTankViewScript.MovementAudio.clip == playerTankModelScript.DrivingAudioClip)
            {
                playerTankViewScript.MovementAudio.clip = playerTankModelScript.IdleAudioClip;
                playerTankViewScript.MovementAudio.pitch = Random.Range(playerTankModelScript.OrignalePitch-playerTankModelScript.PitchRange,playerTankModelScript.OrignalePitch+playerTankModelScript.PitchRange);
                playerTankViewScript.MovementAudio.Play(); 
            }
        }   
        else
        {
            if(playerTankViewScript.MovementAudio.clip == playerTankModelScript.IdleAudioClip)
            {
                playerTankViewScript.MovementAudio.clip = playerTankModelScript.DrivingAudioClip;
                playerTankViewScript.MovementAudio.pitch = Random.Range(playerTankModelScript.OrignalePitch-playerTankModelScript.PitchRange,playerTankModelScript.OrignalePitch+playerTankModelScript.PitchRange);
                playerTankViewScript.MovementAudio.Play(); 
            }  
        }   
    }


    public override void applyDamage(BulletType bulletType , int damage , BulletView bullet)
    { 
        // Debug.Log("hit by Bullet");
        if(bulletType == BulletType.EnemyBullet)
        {
            bullet.DestroyBullet();
            reduceHealth(damage); 
        }
    }

    public override void reduceHealth(int damage)
    {    
        if(playerTankModelScript.Health > 0)
        {
          playerTankModelScript.Health -= damage;
          UpdateTheHealthBar();
         Debug.Log("Health Of Tank " + playerTankModelScript.tankType +" is " + playerTankModelScript.Health);
        }
        if(playerTankModelScript.Health <= 0)
        {
            playerDied = true;
            PlayerTankService.Instance.TriggerPlayerDeathEvent();
            playerTankViewScript.destroyTank();
        }
    }


    public void UpdateTheHealthBar()
    {
        int temp = playerTankModelScript.Health/10;
        
        if(temp <=0 )
        {
            return;
        }

        
        for (int i = playerTankModelScript.TempPointer; i > temp; i--)
        {
            playerTankViewScript.HealthBarImages[i].SetActive(false);
        }
         
        playerTankModelScript.TempPointer = temp; 
       
    }

    public void SetOrientationOfHealthBar()
    { 
        playerTankViewScript.HealthBarCanvas.transform.LookAt(camera.transform);
        playerTankViewScript.HealthBarCanvas.transform.Rotate(0,180,0);
    }

    public void tankMovement()
    {
        // For Z axis
       if(MovementJoystick.Vertical >=  0.2f)
       {
        moveTankForward();
       }
       else if(MovementJoystick.Vertical <= -0.2f)
       {
           moveTankBackWard();
       }       
    }

    
    public void handleTankRotation()
    {
        float xAxis = RotationJoystick.Horizontal;

        if(Mathf.Abs(xAxis) > 0.3f)
        {
           tankRotation();
        }
    }


    public override void moveTankForward()
    {
        playerTankViewScript.TankTransform.position += playerTankViewScript.TankTransform.forward * Time.deltaTime * playerTankModelScript.Speed;
    }


    public override void moveTankBackWard()
    {
        playerTankViewScript.TankTransform.position -= playerTankViewScript.TankTransform.forward * Time.deltaTime * playerTankModelScript.Speed;
    }


    public override void tankRotation()
    {
        playerTankViewScript.TankTransform.Rotate(0,  RotationJoystick.Horizontal * playerTankModelScript.RotationSpeed * Time.deltaTime , 0);
    }
}
