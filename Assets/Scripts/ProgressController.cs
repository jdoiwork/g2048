using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using G2048.Tools;
using UnityEngine;

public class ProgressController : MonoBehaviour {
    public ProgressBarCircle progress;
    public GameObject progressObject;
    public MonoBehaviour progressSource;
    private ProgressSource _ProgressSource;

    // Use this for initialization
    void Start () {
        _ProgressSource = progressSource as ProgressSource;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateActive();
        SetProgress();
    }

    private void UpdateActive()
    {
        progressObject.SetActive(this.Timer().Active);
    }

    private void SetProgress()
    {
        this.progress.BarValue = this.Timer().Ratio() * 100;
    }

    private Timer Timer()
    {
        return _ProgressSource.GetTimer();
    }
}
