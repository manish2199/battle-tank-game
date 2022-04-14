using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour 
{
   [SerializeField] Achievements achievementsList;

   private void OnEnable()
   {
      achievementsList.SubscribeAchievements();
   }


   private void OnDisable()
   {
      achievementsList.UnSubscribeAllAchievements();
   }
   
}




 // void OnEnable()
    // {
    //   PlayerTankService.BullFireAchv +=  ShowBulletFireAchivement;
    //   PlayerTankService.BulletHitAchv += ShowContinousHitAchievement;
    // }

    // void OnDisable()
    // {
    //   PlayerTankService.BullFireAchv -=  ShowBulletFireAchivement;
    //   PlayerTankService.BulletHitAchv += ShowContinousHitAchievement;
    // }


    // private void ShowBulletFireAchivement(BulletFireAchivement achievement)
    // {
    //   print(achievement + " Achievement Unlocked");
    // }

    // private void ShowContinousHitAchievement(ContinuousBulletHit achievement)
    // {
    //   print(achievement + " Achievement Unlocked");
    // }