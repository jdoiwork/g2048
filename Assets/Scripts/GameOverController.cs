using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using G2048.Tools;

public class GameOverController : MonoBehaviour {
    public TextMeshProUGUI score;
    public TextMeshProUGUI playTime;

    public void Start()
    {
        var currentScore = Score.Current;
        Debug.Log(currentScore.Point);

        score.text = ScoreFormatter.Format(currentScore.Point);
        playTime.text = PlayTimeFormatter.Format(currentScore.PlayTime);
    }

    public void Restart()
    {
        Debug.Log("restart");
        GameState.Current.AfterAdSceneName = "Main";
        //SceneManager.LoadScene("Main");
        SceneManager.LoadScene("AdMain");
    }

    public void BackToTitle()
    {
        Debug.Log("title");
        GameState.Current.AfterAdSceneName = "Title";
        //SceneManager.LoadScene("Title");
        SceneManager.LoadScene("AdMain");
    }
}
