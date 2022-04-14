using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFireAchievement : Achievement
{ 
    public int BulletFire;

    public BulletFireAchievement()
    {
        Counter = 0;
        achievement = this;
        achievementType = AchievementType.BulletFireAchievement;
    }

    public BulletFireAchievement(Achievement achievement) : base ( achievement)
    {
        achievement = this;
        achievementType = AchievementType.BulletFireAchievement;
    }

    public override void Subscribe()
    {
        Debug.Log("Subscribed bULLETfIRE");
        PlayerTankService.OnBulletFire += UpdateAchievement;
    }

    public override void UnSubscribe()
    {
        Debug.Log("Unsubscribed bULLETfIRE");
        ResetCounters();
        PlayerTankService.OnBulletFire -= UpdateAchievement;
    }

}


