﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public TextMeshProUGUI text;
    public ulong score = 0;

    public ulong Plus(ulong score)
    {
        this.score += score;
        SetScore(this.score);
        return score;
    }

    public void SetScore(ulong score)
    {
        text.text = string.Format("{0}", score);
    }
}