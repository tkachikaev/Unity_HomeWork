using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private GameObject pinPanel = null;
    [SerializeField] private GameObject winPanel = null;
    [SerializeField] private GameObject lostPanel = null;
    [SerializeField] private GameObject timer = null;
    private bool _timerStatus = false;
    private float _resultTime = 0f;
    private int _pinL = 0;
    private int _pinC = 0;
    private int _pinR = 0;
    public Text timerText = null;
    public Text winPanelText = null;
    public Text pinTextL = null;
    public Text pinTextC = null;
    public Text pinTextR = null;
    public Text logoText = null;
    public float time = 35f;
    
    private void Start()
    {
        StartGame();
    }

    void Update()
    {
        TimerStart();
    }

    /// <summary>
    /// По нажатию включает таймер и отключает кнопку
    /// Включает панель игры. Преход в режим игры.
    /// </summary>
    public void ClicButtonTimerStart()
    {
        _timerStatus = true;
        menuPanel.SetActive(false);
        pinPanel.SetActive(true);
        logoText.text = "";
    }

    /// <summary>
    /// Логика работы таймера (Не запуск)
    /// </summary>
    private void TimerStart()
    {
        if (_timerStatus)
        {
            time -= 1 * Time.deltaTime;
            timerText.text = Mathf.Round(time).ToString();
        }
        //Проигрыш
        if (time <= 0)
        {
            _timerStatus = false;
            lostPanel.SetActive(true);
            menuPanel.SetActive(false);
            pinPanel.SetActive(false);
            logoText.text = "Попробуй еще раз!";
        }
    }

    /// <summary>
    /// Прверка на победу
    /// </summary>
    private void ChekWinGame()
    {
        if (_pinL == 10 && _pinC == 10 && _pinR ==10)
        {
            _timerStatus = false;
            winPanel.SetActive(true);
            pinPanel.SetActive(false);
            _resultTime = 35 - time;
            winPanelText.text = $"Поздравляем!\nВы смогли подобрать шифр за {Mathf.Round(_resultTime)}c." +
                $"\nТеперь вы можете открыть дверь!";
            logoText.text = "Отлично!";
        }
    }

    public void ClickButtonPinL()
    {
        _pinL += 1;
       // pinC -= 1;
        _pinR += 2;
        SetTextPins();

    }
    public void ClickButtonPinC()
    {
        _pinC += 2;
        _pinR -= 1;
        SetTextPins();
    }
    public void ClickButtonPinR()
    {
        _pinC -= 1;
        _pinR += 2;
        SetTextPins();
    }

    /// <summary>
    /// Проверка на числа, не меньше 0 и не более 10
    /// </summary>
    private void CheckPinValid()
    {
        if (_pinL <= 0) _pinL = 0;
        if (_pinL >= 10) _pinL = 10;
        if (_pinC <= 0) _pinC = 0;
        if (_pinC >= 10) _pinC = 10;
        if (_pinR <= 0) _pinR = 0;
        if (_pinR >= 10) _pinR = 10;
    }

    /// <summary>
    /// Запись статуса всех пинов в текст
    /// </summary>
    public void SetTextPins()
    {
        CheckPinValid();
        pinTextL.text = _pinL.ToString();
        pinTextC.text = _pinC.ToString();
        pinTextR.text = _pinR.ToString();
        ChekWinGame();
    }

    /// <summary>
    /// Пероначальный вид окон от StartGame() + 
    /// стандартные параметы.
    /// </summary>
    public void RestartGame()
    {
        time = 35f;
        _pinL = 0;
        _pinC = 0;
        _pinR = 0;
        SetTextPins();
        StartGame();
        _timerStatus = false;
    }

    /// <summary>
    /// Первоначальный вид всех окон
    /// </summary>
    public void StartGame()
    {
        menuPanel.SetActive(true);
        timer.SetActive(true);
        pinPanel.SetActive(false);
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
        logoText.text = "Подбери шифр для двери";
    }
}
