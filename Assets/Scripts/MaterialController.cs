using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    private Dictionary<ulong, Material> mats;

    public Material defaultMaterial;

    // Use this for initialization
    void Awake()
    {
        mats = new Dictionary<ulong, Material>
        {
            {2 , LoadMaterial("Materials/BoxMat2") },
            {4 , LoadMaterial("Materials/BoxMat4") },
            {8 , LoadMaterial("Materials/BoxMat8") },
            {16 , LoadMaterial("Materials/BoxMat16") },
            {32 , LoadMaterial("Materials/BoxMat32") },
            {64 , LoadMaterial("Materials/BoxMat64") },
            {128 , LoadMaterial("Materials/BoxMat128") },
            {256 , LoadMaterial("Materials/BoxMat256") },
            {512 , LoadMaterial("Materials/BoxMat512") },
            {1024 , LoadMaterial("Materials/BoxMat1024") },
            {2048 , LoadMaterial("Materials/BoxMat2048") },

        };

    }

    private Material LoadMaterial(string name)
    {
        var m = Resources.Load<Material>(name);
        Debug.Log(string.Format("LoadMaterial {0}", m?.name));
        return m;
    }


    public Material this[ulong n]
    {
        get
        {
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
