using System.Collections;
using System.Collections.Generic;
using G2048.Tools.Ad;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AdToolFactory.Init();
	}
	
	// Update is called once per frame
	void Update () {
        SceneManager.LoadScene("Title");
	}
}
