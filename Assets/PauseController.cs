using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject pauseUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseOn()
    {
        pauseUI.SetActive(true);
        Debug.Log("Pause ON");
    }

    public void PauseOff()
    {
        pauseUI.SetActive(false);
        Debug.Log("Pause OFF");
    }

}
