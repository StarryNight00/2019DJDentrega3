using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeDisplayText;


    private void Update()
    {
        UpdateTimeDisplay();
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
        else
        {
            timeDisplayText.text = "" + minutes + " : 0" + seconds;
        }
        
    }
}
