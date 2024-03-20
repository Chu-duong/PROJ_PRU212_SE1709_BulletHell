using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public Text timerText; 
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = FormattedTime(timer);
        Debug.Log(timer);
    }

    string FormattedTime(float time)
    {
        int rounded = (int)Mathf.Floor(time);
        int mins = rounded / 60;
        int secs = rounded % 60;
        return $"{(mins < 10 ? "0" + mins : mins)}:{(secs < 10 ? "0" + secs : secs)}";
            
    }
}
