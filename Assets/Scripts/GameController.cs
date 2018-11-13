using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.Scripts.Models;
using UnityEngine;
using System;
using System.Linq;
using Jdoi.Functional;
using Jdoi;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes = new NumberBox[] { };
    private NumberController[] viewBoxes = new NumberController[] { };
    public ScoreController score;
    public ProgressBarCircle progress;

    public GameObject prefab;

    public BoxTools boxTools;
    public float timeRemain;

    public void OnDebugButton()
    {
        AddBox();
        UpdatePosition();
        Debug.Log("hello debug button");
    }

    // Use this for initialization
    void Start()
    {
        boxTools = new BoxTools(0, 3, (box) => score.Plus(box.N));
        timeRemain = 100;
        SetProgress();
        AddBox();
        UpdatePosition();
    }

    private void SetProgress()
    {
        this.progress.BarValue = timeRemain;
    }

    private void AddBox()
    {
        var range = Enumerable.Range(0, boxTools.PosMax + 1);
        var rps =
            range.SelectMany(_ => range, (x, y) => new { x, y })
                    .Where(p => !boxes.Any(box => box.X == p.x && box.Y == p.y))
                    .ToArray();
        if (rps.Any())
        {
            var idx = UnityEngine.Random.Range(0, rps.Length - 1);
            var pos = rps[idx];
            var box = new NumberBox(pos.x, pos.y);

            var newViewBox = Instantiate(prefab).GetComponent<NumberController>();
            newViewBox.SetPos(pos.x, pos.y);

            boxes = box.Cons(boxes).ToArray();
            viewBoxes = newViewBox.Cons(viewBoxes).ToArray();

            score.Plus(box.N);
        }
        else
        {
            // Game Over?
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
        this.timeRemain -= Time.deltaTime;
        this.SetProgress();

        Func<NumberBox, int> getX = box => box.X;
        Func<NumberBox, int> getY = box => box.Y;

        Func<NumberBox, int, NumberBox> moveX = (box, x) => box.MoveX(x);
        Func<NumberBox, int, NumberBox> moveY = (box, y) => box.MoveY(y);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            boxes = boxTools.MergeAsc(boxes, getY, getX, moveX);
            UpdatePosition();
            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            boxes = boxTools.MergeDesc(boxes, getY, getX, moveX);
            UpdatePosition();
            Debug.Log("right");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boxes = boxTools.MergeAsc(boxes, getX, getY, moveY);
            UpdatePosition();
            Debug.Log("up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            boxes = boxTools.MergeDesc(boxes, getX, getY, moveY);
            UpdatePosition();
            Debug.Log("down");
        }
    }
}
