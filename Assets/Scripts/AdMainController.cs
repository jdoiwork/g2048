using System;
using System.Collections;
using System.Collections.Generic;
using G2048.Tools;
using G2048.Tools.Ad;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdMainController : MonoBehaviour {

    private AdTool adTool;
    private bool isShown = false;
    private DateTime startTime;

	// Use this for initialization
	void Start () {
        //AdToolFactory.Init();
        adTool = AdToolFactory.Create();
        startTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            if (IsTimeup() && !isShown)
            {
                Debug.Log("Time UP");
                NextScene();
            }

            if (!isShown && adTool.IsReady())
            {
                isShown = true;
                Debug.Log("isShown = true");
                adTool.Show(AfterAd);
            }

        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    private bool IsTimeup()
    {
        return DateTime.Now - startTime > TimeSpan.FromSeconds(3);
    }

    private void AfterAd(AdResult ar)
    {
        Debug.Log(ar);

        NextScene();
    }

    private static void NextScene()
    {
        var nextScene = GameState.Current.AfterAdSceneName;
        SceneManager.LoadScene(nextScene);
    }
}
