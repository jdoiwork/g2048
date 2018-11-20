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
        score.text = pt.ToString();
    }

    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("Main");
    }
}
