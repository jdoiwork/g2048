using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAnimeController : MonoBehaviour {

    public void OnAnimeFinished()
    {
        var c = GetComponentInParent<PointController>();
        if (c != null)
        {
            c.DestroyGameObject();
        }
        Debug.Log("anime");
    }
}
