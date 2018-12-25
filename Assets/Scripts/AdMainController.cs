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
    private TimeSpan adShownTime = TimeSpan.FromMinutes(15);

    // Use this for initialization
    void Start ()
    {
        if (IsOverAdShownTime())
        {
            Debug.Log("Skip AD");
            NextScene();
        }
        else
        {
            Debug.Log("Show AD");
            InitFields();
        }
    }

    private void InitFields()
    {
        adTool = AdToolFactory.Create();
        startTime = DateTime.Now;
    }

    private bool IsOverAdShownTime()
    {
        return DateTime.Now - GameState.Current.LastAdShownTime < adShownTime;
    }

    // Update is called once per frame
    void Update () {
        try
        {
            if (isShown)
            {
                return;
            }
            else if (IsTimeup())
            {
                Debug.Log("Time UP");
                NextScene();
            }
            else if (adTool.IsReady())
            {
                isShown = true;
                Debug.Log("isShown = true");
                GameState.UpdateLastAdShownTime();
                adTool.Show(AfterAd);
            }
            else
            {
                Debug.Log("Waiting Ad is ready");
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
