using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Пауза
/// </summary>
public class Paused : MonoBehaviour
{
    public GameObject GameStatistics;
    [Header("Отключить сцены во время паузы")]
    public GameObject[] DisableAndEnableWindowsPause;
    private bool _pause = true;
    public void Pause()
    {
        if (_pause)
        {
            Time.timeScale = 0f;
            for (int i = 0; i < DisableAndEnableWindowsPause.GetLength(0); i++)
            {
                DisableAndEnableWindowsPause[i].SetActive(false);
            } //pause
            GameStatistics.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            for (int i = 0; i < DisableAndEnableWindowsPause.GetLength(0); i++)
            {
                DisableAndEnableWindowsPause[i].SetActive(true);
            } //unpause
            GameStatistics.SetActive(false);
        }
        _pause = !_pause;
    }
}
