using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.Scripts.Models;
using UnityEngine;
using System;
using System.Linq;
using Jdoi.Functional;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes;
    private NumberController[] viewBoxes;

    public GameObject prefab;

    public int posMin = 0;
    public int posMax = 3;

    public void OnDebugButton()
    {
        Debug.Log("hello debug button");
    }

    public int RandomPos()
    {
        return UnityEngine.Random.Range(posMin, posMax);
    }

    // Use this for initialization
    void Start()
    {
        boxes = new NumberBox[1];
        viewBoxes = new NumberController[1];

        var newViewBox = Instantiate(prefab).GetComponent<NumberController>();

        var x = RandomPos();
        var y = RandomPos();


        newViewBox.SetPos(x, y);

        var box = new NumberBox();
        box.X = x;
        box.Y = y;

        boxes[0] = box;
        viewBoxes[0] = newViewBox;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var query = boxes.Zip(viewBoxes, (m, v) => new { View = v, m.X, m.Y });
        var query2 = boxes.Zip(viewBoxes, (m, v) => System.Tuple.Create(v, m.X, m.Y));
        query2.Each((view, x, y) => view.SetPos(x, y));

        foreach (var item in query)
        {
            item.View.SetPos(item.X, item.Y);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            boxes[0].X = 0;
            UpdatePosition();
            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            boxes[0].X = 3;
            UpdatePosition();
            Debug.Log("right");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boxes[0].Y = 0;
            UpdatePosition();
            Debug.Log("up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            boxes[0].Y = 3;
            UpdatePosition();
            Debug.Log("down");
        }
    }
}
