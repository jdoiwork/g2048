using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour {

    public TextMesh text;
    public ulong number = 2;
    //public GameObject gameObject;
    public const float sx = 2.0f;
    public const float sy = -2.0f;

    // Use this for initialization
    void Start () {
        this.SetNumberText(this.number);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Up(){
        this.number *= 2;
        this.SetNumberText(this.number);
        this.SetPos(1, 1);
        Debug.Log("UP");
    }

    public NumberController SetNumberText(ulong n)
    {
        Debug.Log(string.Format("SetNumberText {0}", n));
        text.text = n.ToString();
        return this;
    }

    public void Double()
    {
        this.number *= 2;
        this.SetNumberText(this.number);
    }

    public NumberController SetPos(int x, int y)
    {
        var t = this.gameObject.transform;
        t.position = new Vector3(-3f + sx * x, t.position.y, 3f + sy * y);

        return this;
    }
}
