using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.Scripts.Models;
using UnityEngine;
using System;
using System.Linq;
using Jdoi.Functional;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes = new NumberBox[] {};
    private NumberController[] viewBoxes = new NumberController[] {};
    public ScoreController score;

    public GameObject prefab;

    public int posMin = 0;
    public int posMax = 3;

    public void OnDebugButton()
    {
        AddBox();
        UpdatePosition();
        Debug.Log("hello debug button");
    }

    public int RandomPos()
    {
        return UnityEngine.Random.Range(posMin, posMax);
    }

    // Use this for initialization
    void Start()
    {
        score.SetScore(2048);
        AddBox();
        UpdatePosition();
    }

    private void AddBox()
    {
        var range = Enumerable.Range(0, posMax + 1);
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

    private NumberBox[] MergeBox(NumberBox[] bs, NumberBox box)
    {
        if (!bs.Any())
        {
            return bs.Append(box).ToArray();
        }
        else if (bs.Last().N == box.N)
        {
            return bs.Reverse().Skip(1).Reverse().Append(box.Double()).ToArray();

        }
        else
        {
            return bs.Append(box).ToArray();
        }
    }

    private NumberBox[] MergeAsc(NumberBox[] boxes, Func<NumberBox, int> key, Func<NumberBox, int> getPos, Func<NumberBox, int, NumberBox> updatePos)
    {
        return
            boxes.GroupBy(key)
                 .Select(g => g.OrderBy(getPos)
                               .Aggregate(new NumberBox[0], MergeBox)
                               .Select((box, i) => updatePos(box, posMin + i)))
                 .SelectMany(bs => bs)
                 .ToArray();
    }

    private NumberBox[] MergeDesc(NumberBox[] boxes, Func<NumberBox, int> key, Func<NumberBox, int> getPos, Func<NumberBox, int, NumberBox> updatePos)
    {
        return
            boxes.GroupBy(key)
                 .Select(g => g.OrderByDescending(getPos)
                               .Aggregate(new NumberBox[0], MergeBox)
                               .Select((box, i) => updatePos(box, posMax - i)))
                 .SelectMany(bs => bs)
                 .ToArray();
    }

    void Update()
    {
        Func<NumberBox, int> getX = box => box.X;
        Func<NumberBox, int> getY = box => box.Y;

        Func<NumberBox, int, NumberBox> moveX = (box, x) => box.MoveX(x);
        Func<NumberBox, int, NumberBox> moveY = (box, y) => box.MoveY(y);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            boxes = MergeAsc(boxes, getY, getX, moveX);
            UpdatePosition();
            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            boxes = MergeDesc(boxes, getY, getX, moveX);
            UpdatePosition();
            Debug.Log("right");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boxes = MergeAsc(boxes, getX, getY, moveY);
            UpdatePosition();
            Debug.Log("up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            boxes = MergeDesc(boxes, getX, getY, moveY);
            UpdatePosition();
            Debug.Log("down");
        }
    }
}
