﻿using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using Jdoi.Functional;
using Jdoi;
using TouchScript.Gestures;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes = new NumberBox[] { };
    private NumberController[] viewBoxes = new NumberController[] { };
    public ScoreController score;
    public ProgressBarCircle progress;

    public GameObject prefab;

    public BoxTools boxTools;
    public float currentTimeRemain;
    public float maxTimeRemain;
    public float level;
    public float 減衰率 = 0.99f;
    public float 最小猶予時間 = 0.5f;

    public FlickGesture flickGesture;

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
        boxTools = new BoxTools(0, 3, (box) => score.Plus(box.N));
        maxTimeRemain = 4.0f;
        level = 0;
        currentTimeRemain = maxTimeRemain;
        score.Reset();
        SetProgress();
        AddBox();
        UpdatePosition();

        flickGesture.Flicked += FlickGesture_Flicked;
    }

    private int flickCount = 0;

    void FlickGesture_Flicked(object sender, EventArgs e)
    {
        Debug.LogFormat("flick {0}", flickCount++);
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

        var newViewBox = Instantiate(prefab).GetComponent<NumberController>();
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

    void Update()
    {
        this.currentTimeRemain -= Time.deltaTime;
        this.SetProgress();
        if (this.currentTimeRemain < 0)
        {
            level++;
            maxTimeRemain = Mathf.Max(maxTimeRemain * 減衰率, 最小猶予時間);
            this.currentTimeRemain = maxTimeRemain;
            this.AddBox();
        }


        var inputs = new[] {
            new { Code = KeyCode.LeftArrow,  Merge = boxTools.MergeLeft },
            new { Code = KeyCode.RightArrow, Merge = boxTools.MergeRight },
            new { Code = KeyCode.UpArrow,    Merge = boxTools.MergeUp },
            new { Code = KeyCode.DownArrow,  Merge = boxTools.MergeDown },
        };

        var newBoxes =
            inputs.Where(input => Input.GetKeyDown(input.Code))
                  .Aggregate(boxes, (bs, input) => input.Merge(bs));

        if (newBoxes != boxes)
        {
            boxes = newBoxes;
            UpdatePosition();
        }
    }
}
