using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeDisplayText;
    [SerializeField] TextMeshProUGUI scoreDisplayText;


    private void Update()
    {
        UpdateTimeDisplay();
        UpdateScoreDisplay();
    }

    private void UpdateTimeDisplay()
    {
        float currentTime = GameMng.instance.GetCurrentTime();
        int time = Mathf.FloorToInt(currentTime);

        int minutes = time / 60;
        int seconds = time - (minutes * 60);

        if (seconds >= 10)
        {
            timeDisplayText.text = "" + minutes + " : " + seconds;
        }
        else if (minutes < 10)
        {
            timeDisplayText.text = "" + minutes + " : 0" + seconds;
        }
        else if (time < 0)
        {
            timeDisplayText.text = "0 : 00";
        }  
    }

    private void UpdateScoreDisplay()
    {
        int score = GameMng.instance.GetCurrentScore();
        
        if (score <= 0)
        {
            scoreDisplayText.text = "    Score:  ---";
        }
        else
        {
            scoreDisplayText.text = "    Score:  " + score;
        }
        
    }
}
