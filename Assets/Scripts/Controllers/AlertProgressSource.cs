using System.Collections;
using System.Collections.Generic;
using G2048.Models;
using G2048.Tools;
using UnityEngine;

public class AlertProgressSource : MonoBehaviour, ProgressSource {

    public Timer GetTimer()
    {
        return GameState.Current.AlertProgress;
    }
}
