using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankView : TankView
{
    public PlayerTankController playerTankController;

    public void OnTriggerEnter(Collider target)
    {
        print("Called trigger");
        BulletView temp = target.GetComponent<BulletView>();
        if(temp != null)
        { 
           playerController.takeDamage(temp);   
        }
    } 

    public override void destroyBullet(BulletView bullet)
    {
        Destroy(bullet.gameObject);
    }
    
    public override void destroyTank()
    {
        Destroy(this.gameObject);
    }
}
