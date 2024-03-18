using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public Text timerText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F0");
    }
}
