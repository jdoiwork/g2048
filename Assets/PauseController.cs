using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using G2048.Tools;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject pauseUI;

	// Use this for initialization
	void Start () {
        PauseOff();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseOn()
    {
        pauseUI.SetActive(true);
        this.GameRunning = GameRunning.Pause;

        Debug.Log("Pause ON");
    }

    public void PauseOff()
    {
        pauseUI.SetActive(false);
        this.GameRunning = GameRunning.Running;

        Debug.Log("Pause OFF");
    }

    public GameRunning GameRunning
    {
        get
        {
            return GameState.Current.GameRunning;
        }
        set
        {
            GameState.Current.GameRunning = value;
        }
    }
}
