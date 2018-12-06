using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayTimeController : MonoBehaviour {

    public TextMeshProUGUI text;

    public float elapsedTime;

	// Use this for initialization
	void Start () {
        this.elapsedTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.elapsedTime += Time.deltaTime;
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        text.text = ElapsedTimeText(this.elapsedTime);
    }

    private string ElapsedTimeText(float seconds)
    {
        var t = TimeSpan.FromSeconds(seconds);
        var f = ((t.TotalMinutes > 60) ? "{0}:{1:D2}:{2:D2}" : "{1:D2}:{2:D2}");
        return string.Format(f, (int)t.TotalHours, t.Minutes, t.Seconds);
    }


}
