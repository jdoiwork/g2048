using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Jdoi.Functional;
using G2048.IO;
using G2048.Tools;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes = new NumberBox[] { };
    private NumberController[] viewBoxes = new NumberController[] { };
    public ScoreController score;

    public GameObject boxPrefab;
    public GameObject pointPrefab;
    public GameObject pointsObject;

    public Camera mainCamera;

    public BoxTools boxTools;

    public float level;
    public GameConfig gameConfig;

    private UserAction[] actions;

    public void OnDebugButton()
    {
        //AddBox();
        //UpdatePosition();
        GameOverWithForce(true);
        Debug.Log("hello debug button");
    }

    // Use this for initialization
    void Start()
    {
        boxTools = new BoxTools(0, 3, this.OnBoxMerged);
        actions = new[] {
            UserActionFactory.Left(boxTools.MergeLeft),
            UserActionFactory.Right(boxTools.MergeRight),
            UserActionFactory.Up(boxTools.MergeUp),
            UserActionFactory.Down(boxTools.MergeDown),
        };


        gameConfig = GameConfigTools.Difficulty2Config(GameState.Current.Difficulty);

        SetDefaultMaxTimeRemain();
        level = 0;
        ResetTimer();

        score.Reset();

        AddBox();
        UpdatePosition();
    }

    private void SetDefaultMaxTimeRemain()
    {
        GameState.SetNormalProgressMax(gameConfig.MaxCoolTime);
    }

    private void OnBoxMerged(NumberBox box)
    {
        CreatePointChunk(box);
        PlusScore(box);
        ResetTimer();
    }

    private void PlusScore(NumberBox box)
    {
        score.Plus(CalcScore(box));
    }

    private ulong CalcScore(NumberBox box)
    {
        var full = boxes.Length == 16 ? gameConfig.FullScoreScale : 1;
        return box.N * gameConfig.ScoreScale * full;
    }

    private void CreatePointChunk(NumberBox box)
    {
        var point = Instantiate<GameObject>(pointPrefab, pointsObject.transform);
        var pointText = point.GetComponentInChildren<PointController>();
        var trans = point.GetComponent<RectTransform>();
        trans.position = RectTransformUtility.WorldToScreenPoint(this.mainCamera, NumberController.CalcPos(box.X, box.Y, 0));
        pointText.Point = CalcScore(box);
    }

    private void AddBox()
    {
        boxTools.AddBox(boxes, this.CreateBox, this.GameOver);
    }

    private void CreateBox(Pos[] pts)
    {
        var pos = RandomTools.RandomElement(pts);
        var num = RandomTools.RandomElement(gameConfig.NumberRange);
        var box = new NumberBox(pos.X, pos.Y, num);

        var newViewBox = Instantiate(boxPrefab).GetComponent<NumberController>();
        newViewBox.SetPos(pos.X, pos.Y).SetNumberText(num);

        boxes = box.Cons(boxes).ToArray();
        viewBoxes = newViewBox.Cons(viewBoxes).ToArray();

        PlusScore(box);

        ResetTimer();
    }

    private void GameOver()
    {
        GameOverWithForce(false);
    }

    private void GameOverWithForce(bool force)
    {
        if (boxTools.IsDead(boxes) || force)
        {
            score.Save();
            SceneManager.LoadScene("GameOver");
        }
    }

    private void UpdatePosition()
    {
        boxes.Zip(viewBoxes, (m, v) => Tuple.Create(v, m.X, m.Y, m.N))
             .Each((view, x, y, n) => view.SetPos(x, y).SetNumberText(n));

        var len = boxes.Length;
        foreach (var item in viewBoxes.Skip(len))
        {
            UnityEngine.Object.Destroy(item.gameObject);
        }

        viewBoxes = viewBoxes.Take(len).ToArray();
    }

    public void RequestNext()
    {
        level++;
        GameState.ReduceNormalProgressMax(gameConfig);

        this.AddBox();
    }

    public void RequestBomb()
    {
        if (score.IsBombEnabed())
        {
            boxes = boxTools.Bomb(boxes);
            UpdatePosition();
            score.Bomb();
            SetDefaultMaxTimeRemain();
            Debug.Log("bomb");
        }
    }

    void Update()
    {
        GameState.ReduceNormalProgress(Time.deltaTime);

        if (GameState.IsOverNormalProgress())
        {
            RequestNext();
        }


        MouseState.UpdateCurrent();

        var newBoxes = NextBoxes();

        if (newBoxes != boxes)
        {
            boxes = newBoxes;
            UpdatePosition();
        }
    }

    private void ResetTimer()
    {
        GameState.ResetNormalProgress();
    }

    private NumberBox[] NextBoxes()
    {
        return
            actions
                .Where(action => action.Input.HasOccured())
                .Aggregate(boxes, (bs, action) => action.Merge(bs));
    }
}
