﻿using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Jdoi.Functional;
using Jdoi;
using G2048.IO;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes = new NumberBox[] { };
    private NumberController[] viewBoxes = new NumberController[] { };
    public ScoreController score;
    public ProgressBarCircle progress;

    public GameObject boxPrefab;
    public GameObject pointPrefab;
    public GameObject pointsObject;
    public Camera camera;

    public BoxTools boxTools;
    public float currentTimeRemain;
    public float maxTimeRemain;
    public float level;
    public float 減衰率 = 0.99f;
    public float 最小猶予時間 = 0.5f;


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

        SetDefaultMaxTimeRemain();
        level = 0;
        ResetTimer();

        score.Reset();
        SetProgress();
        AddBox();
        UpdatePosition();
    }

    private void SetDefaultMaxTimeRemain()
    {
        maxTimeRemain = 4.0f;
    }

    private void OnBoxMerged(NumberBox box)
    {
        CreatePointChunk(box);
        score.Plus(box.N);
        ResetTimer();
    }

    private void CreatePointChunk(NumberBox box)
    {
        var point = Instantiate<GameObject>(pointPrefab, pointsObject.transform);
        var pointText = point.GetComponentInChildren<PointController>();
        var trans = point.GetComponent<RectTransform>();
        trans.position = RectTransformUtility.WorldToScreenPoint(this.camera, NumberController.CalcPos(box.X, box.Y, 0));
        pointText.Point = box.N;
    }

    private void SetProgress()
    {
        this.progress.BarValue = currentTimeRemain / maxTimeRemain * 100;
    }

    private void AddBox()
    {
        boxTools.AddBox(boxes, this.CreateBox, this.GameOver);
    }

    private void CreateBox(Pos[] pts)
    {
        var idx = UnityEngine.Random.Range(0, pts.Length - 1);
        var pos = pts[idx];
        var box = new NumberBox(pos.X, pos.Y);

        var newViewBox = Instantiate(boxPrefab).GetComponent<NumberController>();
        newViewBox.SetPos(pos.X, pos.Y);

        boxes = box.Cons(boxes).ToArray();
        viewBoxes = newViewBox.Cons(viewBoxes).ToArray();

        score.Plus(box.N);

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
        maxTimeRemain = Mathf.Max(maxTimeRemain * 減衰率, 最小猶予時間);
        ResetTimer();
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
        this.currentTimeRemain -= Time.deltaTime;
        this.SetProgress();
        if (this.currentTimeRemain < 0)
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
        this.currentTimeRemain = maxTimeRemain;
    }

    private NumberBox[] NextBoxes()
    {
        return
            actions
                .Where(action => action.Input.HasOccured())
                .Aggregate(boxes, (bs, action) => action.Merge(bs));
    }
}
