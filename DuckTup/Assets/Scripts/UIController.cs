using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI_Convas Управление")]
    public GameObject UI_Info;
    public GameObject UI_Lost;
    [Header("UI_Info Текстовые ссылки")]
    public Text TextScore;
    public Text TextTimer;
    [Header("UI_Lost Текстовые ссылки")]
    public Text TextInfo;

    /// <summary>
    /// Добавляет Score, обновляет значение на экране
    /// </summary>
    /// <param name="Score"></param>
    /// <returns></returns>
    public string SetScoreText(int Score)
    {
        return TextScore.text = Score.ToString();
    }
    /// <summary>
    /// Добавляет Time, обновляет значение на экране
    /// </summary>
    /// <param name="Timer"></param>
    /// <returns></returns>
    public string SetTimerText(float Timer)
    {
        return TextTimer.text = Mathf.Round(Timer).ToString();

    }

    /// <summary>
    /// Включаем конвас UI_Los
    /// </summary>
    public void EnableUILost()
    {
        UI_Lost.SetActive(true);
    }
}
