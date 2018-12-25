using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using G2048.Behaviors;
using G2048.Models;
using G2048.Tools;

public class PlayTimeController : MonoBehaviour, StateSavable
{

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
        text.text = PlayTimeFormatter.Format(this.elapsedTime);
    }

    public void Save()
    {
        Score.Current.PlayTime = this.elapsedTime;
        Debug.Log("PlayTime Save");
    }
}
