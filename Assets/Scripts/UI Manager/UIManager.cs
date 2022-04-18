using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : GenericSingleton<UIManager>
{
   [SerializeField] TextMeshProUGUI ScoreText;

   [SerializeField] TextMeshProUGUI AchievementText;
   [SerializeField] GameObject AchievementPanel ;

   void OnEnable()
   { 
      Achievement.OnAchievementAcomplished += ShowAchievementText;
      PlayerTankService.UpdateScoreUIText += UpdateScoreText;
   }

   void OnDisable()
   {
      Achievement.OnAchievementAcomplished -= ShowAchievementText;
      PlayerTankService.UpdateScoreUIText -= UpdateScoreText;
   }

   private void ShowAchievementText(Achievement achievement)
   {
      StartCoroutine(AchievementTextCoroutin(achievement));
   }

   IEnumerator AchievementTextCoroutin(Achievement achievement)
   {
      print("Inside Coroutine");
      AchievementText.text = achievement.AchievementText;
       
      yield return null;

      AchievementPanel.gameObject.SetActive(true);

      yield return new WaitForSeconds(3f);

      AchievementPanel.gameObject.SetActive(false);
   }

   private void UpdateScoreText(int Score)
   {
      ScoreText.text = "Score = " + Score; 
   }
}
