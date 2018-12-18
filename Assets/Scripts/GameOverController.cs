using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using G2048.Tools;

public class GameOverController : MonoBehaviour {
    public TextMeshProUGUI score;

    public void Start()
    {
        var pt = Score.Current.Point;
        Debug.Log(pt);
        score.text = string.Format("{0:N0}", pt);
        score.text = ScoreFormatter.Format(pt);
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
