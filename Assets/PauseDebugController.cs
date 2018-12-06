using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using G2048.Tools;

public class PauseDebugController : MonoBehaviour {

    public TextMeshProUGUI textUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        textUI.text = GameState.Current.GameRunning.ToString();
	}
}
