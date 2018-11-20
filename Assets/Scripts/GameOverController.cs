using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    public void Start()
    {
        Debug.Log(Score.Current.Point);
    }

    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("Main");
    }
}
