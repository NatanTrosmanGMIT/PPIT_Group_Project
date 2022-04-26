using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 1000f;

     [SerializeField] Text CountdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

     void Update()
    {
        currentTime -= 1* Time.deltaTime;
        CountdownText.text=currentTime.ToString("0");

        

        if(currentTime <= 0){
            currentTime = 0;
        }
        if(currentTime <= 10){
            CountdownText.color=Color.red;
        }
    }
}

   
