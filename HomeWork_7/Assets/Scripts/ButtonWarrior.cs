using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка создания Война, имеет настройки по откату 
/// и проверки на возможность создания.
/// </summary>
public class ButtonWarrior : MonoBehaviour
{
    public GameRecources GameRecources;
    public SoundAndMusik SoundAndMusik;
    public Image DynamicImage;
    public Text TextHelp;
    public Text TextHelpPrice;
    public float CoolDown = 4f;
    private bool _canPush; //Доступность нажатия кнопки
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
        if (GameRecources.Gold < GameRecources.WarriorPrice) 
        {
            SetHelpTextNoMoney();
        }
        if (GameRecources.Gold >= GameRecources.WarriorPrice && _canPush == false)
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
        // списание до отката кнопки.
        if (_transaction) GameRecources.SpendGold(GameRecources.WarriorPrice); _transaction = false;
        SetHelpTextCoolDownTime();
        _currentTime -= Time.deltaTime;
        DynamicImage.fillAmount = _currentTime / CoolDown;
        if (_currentTime <= 0)
        {
            SoundAndMusik.SoundCreateWarrior();
            _canPush = false;
            GameRecources.GetWarrior();
            _currentTime = CoolDown;
            DynamicImage.fillAmount = 1f;
            TextHelp.text = "Обучить\nВойна";
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
    /// Выводим на кнопку цену покупки Война
    /// </summary>
    private void SetHelpTextPrice()
    {
        TextHelpPrice.text = GameRecources.WarriorPrice.ToString();
    }
    private void Update()
    {
        if (_canPush) ClickButton();
    }
}
