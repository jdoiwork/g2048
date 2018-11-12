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
        var x = RandomPos();
        var y = RandomPos();

        var box = new NumberBox(x, y);

        var newViewBox = Instantiate(prefab).GetComponent<NumberController>();
        newViewBox.SetPos(x, y);

        boxes = box.Cons(boxes).ToArray();
        viewBoxes = newViewBox.Cons(viewBoxes).ToArray();
    }

    private void UpdatePosition()
    {
        boxes.Zip(viewBoxes, (m, v) => Tuple.Create(v, m.X, m.Y))
             .Each((view, x, y) => view.SetPos(x, y));
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            boxes = boxes.Select((box) => box.MoveX(posMin)).ToArray();
            boxes = boxes.Select((box) => box.MoveX(posMin)).ToArray();
            UpdatePosition();
            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            boxes = boxes.Select((box) => box.MoveX(posMax)).ToArray();
            UpdatePosition();
            Debug.Log("right");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boxes = boxes.Select((box) => box.MoveY(posMin)).ToArray();
            UpdatePosition();
            Debug.Log("up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            boxes = boxes.Select((box) => box.MoveY(posMax)).ToArray();
            UpdatePosition();
            Debug.Log("down");
        }
    }
}
