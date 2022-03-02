using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;

    void OnEnable()
    { 
       PlayerTankService.UpdateScoreUIText += UpdateScoreText;
    }

    void OnDisable()
    {
       PlayerTankService.UpdateScoreUIText -= UpdateScoreText;
    }

    private void UpdateScoreText(int Score)
    {
       scoreText.text = "Score = " + Score; 
    }
}
