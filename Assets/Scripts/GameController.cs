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
            //Debug.Log(box.Double().N);
            return bs.Reverse().Skip(1).Reverse().Append(box.Double()).ToArray();

        }
        else
        {
            return bs.Append(box).ToArray();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            boxes =
                boxes.GroupBy((box) => box.Y)
                     .Select(g => g.OrderBy(box => box.X).Aggregate(new NumberBox[0], MergeBox).Select((box, i) => box.MoveX(posMin + i)))
                     .SelectMany(bs => bs)
                     .ToArray();
            UpdatePosition();
            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            boxes =
                boxes.GroupBy((box) => box.Y)
                     .Select(g => g.OrderByDescending(box => box.X).Aggregate(new NumberBox[0], MergeBox).Select((box, i) => box.MoveX(posMax - i)))
                .SelectMany(bs => bs)
                .ToArray();
            UpdatePosition();
            Debug.Log("right");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boxes =
                boxes.GroupBy((box) => box.X)
                     .Select(g => g.OrderBy(box => box.Y).Aggregate(new NumberBox[0], MergeBox).Select((box, i) => box.MoveY(posMin + i)))
                     .SelectMany(bs => bs)
                     .ToArray();
            UpdatePosition();
            Debug.Log("up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            boxes =
                boxes.GroupBy((box) => box.X)
                .Select(g => g.OrderByDescending(box => box.Y).Aggregate(new NumberBox[0], MergeBox).Select((box, i) => box.MoveY(posMax - i)))
                .SelectMany(bs => bs)
                .ToArray();
            UpdatePosition();
            Debug.Log("down");
        }
    }
}
