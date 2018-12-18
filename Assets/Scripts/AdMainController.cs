using System.Collections;
using System.Collections.Generic;
using G2048.Tools;
using G2048.Tools.Ad;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdMainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var adTool = AdToolFactory.Create();
        adTool.Show(AfterAd);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void AfterAd(AdResult ar)
    {
        Debug.Log(ar);

        var nextScene = GameState.Current.AfterAdSceneName;
        SceneManager.LoadScene(nextScene);
    }
}
