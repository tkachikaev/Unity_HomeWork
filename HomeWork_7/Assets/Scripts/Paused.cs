using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    private bool paused;
    public void PausedAndPlay()
    {
        if (paused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        paused = !paused; // true - flse / false true
    }
}
