using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp.Assets.Scripts.Models;
using UnityEngine;
using System;
using System.Linq;

public class GameController : MonoBehaviour
{
    private NumberBox[] boxes;
    private NumberController[] viewBoxes;

    public GameObject prefab;

    public void OnDebugButton()
    {
        Debug.Log("hello debug button");
    }

    // Use this for initialization
    void Start()
    {
        boxes = new NumberBox[1];
        viewBoxes = new NumberController[1];

        var newViewBox = Instantiate(prefab).GetComponent<NumberController>();
        newViewBox.SetPos(2, 3);

        var box = new NumberBox();
        box.X = 2;
        box.Y = 3;

        boxes[0] = box;
        viewBoxes[0] = newViewBox;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var query = boxes.Zip(viewBoxes, (m, v) => new { View = v, m.X, m.Y });

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
