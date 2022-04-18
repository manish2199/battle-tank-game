using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HitWithoutMissAchievement : Achievement
{
    public int HIT;

    public HitWithoutMissAchievement()
    {
        Counter = 0;
        achievement = this;
        achievementType = AchievementType.HitWithoutMissAchievement;
    }
    
    public HitWithoutMissAchievement(Achievement achievement) : base (achievement)
    {
        achievement = this;
        achievementType = AchievementType.HitWithoutMissAchievement;        
    }

    public override void Subscribe() 
    {
       Debug.Log("Subscribed HitWithoutMiss");
       EnemyTankService.OnEnemeyHit += UpdateAchievement;
       BulletService.OnPlayerMissShot += ResetCounters;
    }

    public override void UnSubscribe()
    {
       Debug.Log("Unsubscribed HitWithoutMiss");
       ResetCounters();
       EnemyTankService.OnEnemeyHit -= UpdateAchievement;
       BulletService.OnPlayerMissShot -= ResetCounters;
    }
   
}

