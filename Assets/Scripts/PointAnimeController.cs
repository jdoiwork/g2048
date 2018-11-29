using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAnimeController : MonoBehaviour {

    public void OnAnimeFinished()
    {
        var c = GetComponentInParent<PointController>();
        c.DestroyGameObject();
        Debug.Log("anime");
    }
}
