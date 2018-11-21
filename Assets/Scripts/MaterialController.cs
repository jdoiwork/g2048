using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour {
    private Dictionary<ulong, Material> mats;

    public Material defaultMaterial;

	// Use this for initialization
	void Start () {
        mats = new Dictionary<ulong, Material>
        {
            {2 , LoadMaterial("Materials/BoxMat") },
            {4 , LoadMaterial("Materials/BoxMat4") },

        };

    }

    private Material LoadMaterial(string name)
    {
        var m = Resources.Load<Material>(name);
        Debug.Log(string.Format("LoadMaterial {0}", m?.name));
        return m;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Material this[ulong n]
    {
        get {
            Material mat;

            if (mats.TryGetValue(n, out mat))
            {
                if (mats == null)
                {
                    Debug.Log("Material({0} is NULL!!!!)", mat);
                }

                return mat ?? defaultMaterial;
            }
            else
            {
                return defaultMaterial;
            }
        }
    }
}
