using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bombCostText;
    public Button bombButton;

    public ulong score = 0;
    public ulong bombCost = 2;

    void Start()
    {
        SetBombCost(bombCost);
    }

    void Update()
    {
        bombButton.interactable = IsBombEnabed();

    }

    public ulong Plus(ulong score)
    {
        this.score += score;
        SetScore(this.score);
        return score;
    }

    public void Bomb()
    {
        this.score -= bombCost;
        SetScore(this.score);
        bombCost *= 2;
        SetBombCost(bombCost);
    }

    public bool IsBombEnabed()
    {
        return bombCost <= score;
    }

    public void SetScore(ulong score)
    {
        scoreText.text = string.Format("{0}", score);
    }

    public void SetBombCost(ulong cost)
    {
        bombCostText.text = string.Format("Cost -{0}", cost);
    }

    public void Reset()
    {
        Score.Reset();
    }

    public void Save()
    {
        Score.Current.Point = this.score;
    }
}
