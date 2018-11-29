using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberController : MonoBehaviour
{

    public TextMesh text;
    public ulong number = 2;
    //public GameObject gameObject;
    public const float sx = 2.0f;
    public const float sy = -2.0f;
    private MaterialController mats;

    void Awake()
    {
        mats = FindObjectOfType<MaterialController>();
    }

    // Use this for initialization
    void Start()
    {
        this.SetNumberText(this.number);
    }

    public void DebugUp()
    {
        this.number *= 2;
        this.SetNumberText(this.number);
        this.SetPos(1, 1);
        Debug.Log("UP");
    }

    public NumberController SetNumberText(ulong n)
    {
        //Debug.Log(string.Format("SetNumberText {0}", n));
        this.number = n;
        text.text = n.ToString();
        this.UpdateMaterial();
        return this;
    }

    private void UpdateMaterial()
    {
        var r = this.GetComponent<MeshRenderer>();
        if (mats == null)
        {
            Debug.LogError("mats is NULL!!!!");
        }
        else
        {
            var m = mats[this.number];

            r.material = m;
        }
    }

    public NumberController SetPos(int x, int y)
    {
        var t = this.gameObject.transform;
        t.position = CalcPos(x, y, t.position.y);

        return this;
    }

    public static Vector3 CalcPos(int x, int y, float h)
    {
        return new Vector3(-3f + sx * x, h, 3f + sy * y);
    }
}
