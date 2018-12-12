using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour {
    public TextMeshProUGUI score;

    public void Start()
    {
        var pt = Score.Current.Point;
        Debug.Log(pt);
        score.text = string.Format("{0:N0}", pt);
    }

    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("Main");
    }

    public void BackToTitle()
    {
        Debug.Log("title");
        SceneManager.LoadScene("Title");
    }
}
