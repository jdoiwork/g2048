using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

using G2048.Tools;
using G2048.Models;

public class TitleController : MonoBehaviour
{

    public Dropdown dropdown;

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
}
