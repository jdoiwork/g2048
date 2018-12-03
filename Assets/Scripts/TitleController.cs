using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using G2048.Tools;

public class TitleController : MonoBehaviour {

    public Dropdown dropdown;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDifficultChanged(int n)
    {
        var gds = GameConfigTools.GameDifficulties;
        var gd = gds[dropdown.value];
        Debug.Log(gd);
    }
}
