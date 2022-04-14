using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AchievementCell 
{
    [SerializeField] AchievementType achievementType = AchievementType.None;
    
    [SerializeReference] Achievement achievementConstraints;

    private AchievementType lastType;
    
    private Achievement savedAchievement;

    public AchievementCell()
    {
        lastType = achievementType;
    }

    public void SubscribeAchievement()
    {
        achievementConstraints.Subscribe();
    }

    public void UnSubscribeAchievement()
    {
        achievementConstraints.UnSubscribe();
    }

    public void Validate()
    {
        if(achievementType != lastType)
        {
            lastType = achievementType;
            savedAchievement = achievementConstraints;
            achievementConstraints = UpdateAchievement(savedAchievement);
            savedAchievement = null;
        }
    }

    private Achievement UpdateAchievement(Achievement achievement)
    {
        Achievement newAchievement = null; 

        if(achievementType == AchievementType.BulletFireAchievement)
        { 
            newAchievement = (achievement!= null)? new BulletFireAchievement(achievement) : new BulletFireAchievement();
        }  
        if(achievementType == AchievementType.HitWithoutMissAchievement)
        {
            newAchievement = (achievement!= null)? new HitWithoutMissAchievement(achievement) : new HitWithoutMissAchievement();
        }    
        
        return newAchievement;
    }

}
