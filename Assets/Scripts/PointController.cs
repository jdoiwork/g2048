using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointController : MonoBehaviour {

    public ulong Point
    {
        get;
        set;
    }

    public TextMeshProUGUI textUI;

	// Use this for initialization
	void Start ()
    {
        textUI.text = FormatPoint(this.Point);
    }

    private string FormatPoint(ulong p)
    {
        return string.Format("+{0}", p);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
        Debug.Log("anime");
    }
}
