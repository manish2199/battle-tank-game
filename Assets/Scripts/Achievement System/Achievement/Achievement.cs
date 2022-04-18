using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public abstract class Achievement
{
    public Achievement() {}

    public Achievement(Achievement achievement)
    {
        Counter = 0;
        X_Amount_ForBronzeMedal = achievement. X_Amount_ForBronzeMedal ;
        X_Amount_ForSilverMedal =  achievement.X_Amount_ForSilverMedal ;
        X_Amount_ForGoldMedal = achievement. X_Amount_ForGoldMedal;
    }

    protected Achievement achievement;

    [HideInInspector] protected int Counter;
    
    [SerializeField] protected int X_Amount_ForBronzeMedal;
    [SerializeField] protected int X_Amount_ForSilverMedal;
    [SerializeField] protected int X_Amount_ForGoldMedal;

    protected string Achievementtext;

    public string AchievementText { get { return Achievementtext; } }

    protected AchievementType achievementType;

    public static event Action<Achievement> OnAchievementAcomplished;
    
    public abstract void Subscribe();

    public abstract void UnSubscribe();

    protected void InvokeAchievementAcomplished(Achievement achievement)
    {
        OnAchievementAcomplished?.Invoke(achievement);
    }

    protected virtual void UpdateAchievement()
    {
       Counter ++;

       if(Counter == X_Amount_ForBronzeMedal)
       {
            Debug.Log("Aciheved Bronze");
           SetAchievementText(MedalTypes.BronzeMedal,achievementType);
           InvokeAchievementAcomplished(achievement);
       }
       else if( Counter == X_Amount_ForSilverMedal)
       {
           Debug.Log("Aciheved Silver");
           SetAchievementText(MedalTypes.SilverMedal,achievementType);
           InvokeAchievementAcomplished(achievement);
       }
       else if( Counter == X_Amount_ForGoldMedal)
       {
           SetAchievementText(MedalTypes.GoldMedal,achievementType);
           InvokeAchievementAcomplished(achievement);
        //    this.UnSubscribe(); 
       }
    } 

    protected virtual void SetAchievementText(MedalTypes medal,AchievementType achievementType)
    {
        Achievementtext = "Player Achieved "+ medal.ToString() +" in " + achievementType.ToString();
    }

    protected virtual void ResetCounters()
    {
        Counter = 0;
    }

} 


public enum AchievementType
{
    None,
    BulletFireAchievement, 
    HitWithoutMissAchievement,
    HighestKillAchievement
}


public enum MedalTypes
{   
    None,
    BronzeMedal,
    SilverMedal,
    GoldMedal
}