using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public TextMeshProUGUI text;

    public void SetScore(ulong score)
    {
        text.text = string.Format("{0}", score);
    }
}
