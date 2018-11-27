using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayTimeController : MonoBehaviour {

    public TextMeshProUGUI text;

    public TimeSpan elapsedTime;
    public DateTime startTime;

	// Use this for initialization
	void Start () {
        this.startTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.elapsedTime = CalcElapsedTime();
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        text.text = ElapsedTimeText(this.elapsedTime);
    }

    private string ElapsedTimeText(TimeSpan t)
    {
        var f = ((t.TotalMinutes > 60) ? "{0}:{1:D2}:{2:D2}" : "{1:D2}:{2:D2}");
        return string.Format(f, (int)t.TotalHours, t.Minutes, t.Seconds);
    }

    private TimeSpan CalcElapsedTime()
    {
        return DateTime.Now - this.startTime;
    }
}
