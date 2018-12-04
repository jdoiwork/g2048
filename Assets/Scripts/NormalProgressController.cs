using System.Collections;
using System.Collections.Generic;
using G2048.Tools;
using UnityEngine;

public class NormalProgressController : MonoBehaviour {
    public ProgressBarCircle progress;
    public GameObject progressObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateActive();
        SetProgress();
    }

    private void UpdateActive()
    {
        progressObject.SetActive(!GameState.IsOverNormalProgress());
    }

    private void SetProgress()
    {
        var timer = GameState.Current.NormalProgress;
        this.progress.BarValue = timer.Ratio() * 100;
    }
}
