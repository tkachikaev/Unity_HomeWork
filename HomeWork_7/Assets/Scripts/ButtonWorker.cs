using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка создания Рабочего, имеет настройки по откату 
/// и проверки на возможность создания.
/// </summary>
public class ButtonWorker : MonoBehaviour
{
    public GameRecources GameRecources;
    public SoundAndMusik SoundAndMusik;
    public Image DynamicImage;
    public Text TextHelp;
    public Text TextHelpPrice;
    public float CoolDown = 2f;
    private bool _canPush;
    private float _currentTime;
    private bool _transaction = true; //Проверка на покупку, после транзакции запрет на покупку

    private void Start()
    {
        SetHelpTextPrice();
        _currentTime = CoolDown;
    }
    /// <summary>
    /// Нажатие кнопки
    /// </summary>
    public void ClickButton()
    {
        if (GameRecources.Gold < GameRecources.WorkerPrice)
        {
            SetHelpTextNoMoney();
        }
        if (GameRecources.Gold >= GameRecources.WorkerPrice && _canPush == false)
        {
            _canPush = true;
        }
        if (_canPush == true)
        {
            ButtonLogic();
        }
    }
    /// <summary>
    /// Логика работы кнопки
    /// </summary>
    public void ButtonLogic()
    {
        // После списания денег, включаем запрет на 
        // списание до отката кнопки _transaction.
        if (_transaction) GameRecources.SpendGold(GameRecources.WorkerPrice); _transaction = false;
        SetHelpTextCoolDownTime();
        _currentTime -= Time.deltaTime;
        DynamicImage.fillAmount = _currentTime / CoolDown;
        if (_currentTime <= 0)
        {
            SoundAndMusik.SoundCreateWorker();
            _canPush = false;
            GameRecources.GetWorker();
            _currentTime = CoolDown;
            DynamicImage.fillAmount = 1f;
            TextHelp.text = "Обучить\nРабочего";
            _transaction = true;
        }
        
    }
    /// <summary>
    /// Сообщение о недостатке денег для покупки (Красным цветом).
    /// </summary>
    public void SetHelpTextNoMoney()
    {
        TextHelp.color = Color.red;
        TextHelp.text = $"Мало\nденег!";
    }
    /// <summary>
    /// Таймер отката кнопки, записываем в текст.
    /// </summary>
    public void SetHelpTextCoolDownTime()
    {
        TextHelp.color = Color.black;
        TextHelp.text = $"Ждите: {Mathf.Round(_currentTime)}";
    }
    /// <summary>
    /// Выводим на кнопку цену покупки рабочего
    /// </summary>
    private void SetHelpTextPrice()
    {
        TextHelpPrice.text = GameRecources.WorkerPrice.ToString();
    }
    private void Update()
    {
        if (_canPush) ClickButton();
    }

}
