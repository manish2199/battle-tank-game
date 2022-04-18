using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "AchievementsScriptableObject", menuName = "ScriptableObject/NewAchievementsScriptableObject")] 
public class Achievements : ScriptableObject
{
   [SerializeField] AchievementCell[] achievementCellList;

    private void OnValidate()
    { 
        //  ValidateAllAchievementCell();        
    } 

    public void SubscribeAchievements()
    {
        for ( int i =0; i<achievementCellList.Length; i++)
        {
            achievementCellList[i].SubscribeAchievement();
        }
    }

    public void UnSubscribeAllAchievements()
    {
       for ( int i =0; i<achievementCellList.Length; i++)
        {
            achievementCellList[i].UnSubscribeAchievement();
        }
    }


    void ValidateAllAchievementCell()
    {
        for( int i =0; i<achievementCellList.Length; i++)
        {
            achievementCellList[i].Validate();
        }
    }



}
