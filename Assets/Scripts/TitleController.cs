using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

using G2048.Tools;
using G2048.Models;
using System;

public class TitleController : MonoBehaviour
{
    public string nextScene = "Main"; 
    public TMP_Dropdown dropdown;

    // Use this for initialization
    void Start()
    {
        SetCurrentDifficulty();
    }

    private void SetCurrentDifficulty()
    {
        var gds = GameConfigTools.GameDifficulties;
        var value = (int)gds.First(gd => gd == GameState.Current.Difficulty);

        dropdown.value = value;
    }

    public void OnDifficultChanged(int n)
    {
        Debug.Log(this.GameDifficulty);
    }

    public GameDifficulty GameDifficulty {
        get {
            var gds = GameConfigTools.GameDifficulties;
            var gd = gds[dropdown.value];

            return gd;
        }
    }

    public void OnStartPressed()
    {
        UpdateCurrentDifficulty();
        LoadMainScene();
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void UpdateCurrentDifficulty()
    {
        GameState.Current.Difficulty = this.GameDifficulty;
    }
}
