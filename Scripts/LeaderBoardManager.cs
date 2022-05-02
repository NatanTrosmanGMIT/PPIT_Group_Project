using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LeaderBoardManager : MonoBehaviour
{
    public TMPro.TMP_Text[] HighScoreLabels;
    void Start()
    {
        for(int i=1; i<=5; i++){
            int myScore = PlayerPrefs.GetInt("HS" + i);
            string myName = PlayerPrefs.GetString("HSN" + i);
            HighScoreLabels[i-1].text = i + ". " + myName + ": " + myScore.ToString();
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
