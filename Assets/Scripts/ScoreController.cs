using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using G2048.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bombCostText;
    public Button bombButton;
    public GameConfig gameConfig;

    public ulong score = 0;
    public ulong bombCost = 2;

    void Start()
    {
        gameConfig = GameConfigTools.Difficulty2Config(GameState.Current.Difficulty);
        bombCost = gameConfig.InitialBombCost;

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
        bombCost *= gameConfig.BombCostScale;
        SetBombCost(bombCost);
    }

    public bool IsBombEnabed()
    {
        return bombCost <= score;
    }

    public void SetScore(ulong score)
    {
        scoreText.text = ScoreFormatter.Format(score);
    }

    public void SetBombCost(ulong cost)
    {
        var costText = ScoreFormatter.Format(cost);
        bombCostText.text = string.Format("Cost -{0}", costText);
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
