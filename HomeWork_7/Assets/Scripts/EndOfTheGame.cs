using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheGame : MonoBehaviour
{
    public GameObject ButtonStatistics;
    public GameObject ButtonRestart;
    public GameObject VictoryWindow;
    public GameObject DefeatWindow;
    public GameObject[] DisableWindows;

    /// <summary>
    /// Включает окно победы, отключает остальные окна
    /// </summary>
    public void GameWin()
    {
        VictoryWindow.SetActive(true);
        ButtonRestart.SetActive(true);
        ButtonStatistics.SetActive(true);
        for (int i = 0; i < DisableWindows.Length; i++)
        {
            DisableWindows[i].SetActive(false);
            ButtonRestart.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    /// <summary>
    /// Включает окно поражения, отключает другие окна
    /// </summary>
    public void GameLoos()
    {
        DefeatWindow.SetActive(true);
        ButtonRestart.SetActive(true);
        ButtonStatistics.SetActive(true);
        for (int i = 0; i < DisableWindows.Length; i++)
        {
            DisableWindows[i].SetActive(false);
            Time.timeScale = 0f;
        }
    }

    /// <summary>
    /// Метод перезагружает сцену / Возвращает в исходное состояние / Перезапуск игры
    /// </summary>
    public void ClickButtonRestartGoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }

}
