using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Окно доходов и расходов каждое N время
/// </summary>
public class TableIncomeAndExpenses : MonoBehaviour
{
    [Header("Ссылки на классы")]
    public GameRecources GameRecources;
    [Header("Ссылки на текстовые и графические файлы (DinamicText)")]
    public Image DynamicImage;
    public Text IncomeText;
    public Text SalaryText;
    public Text ResultText;
    [Header("Тик после которого происходит получения и списание денег")]
    public float Time = 4f;
    private int _income;
    private int _salary;
    private int _result;
    private float _currentTime;

    /// <summary>
    /// Записываем сколько прибыли получаем каждын _time секунд
    /// </summary>
    /// <param name="unyt"></param>
    /// <param name="gold"></param>
    /// <returns></returns>
    private string SetTextIncomeGold(int unyt, int gold)
    {
        _income = unyt * gold;
        return IncomeText.text = _income.ToString();
    }

    /// <summary>
    /// Записываем сколько денег тратим каждые _time секунд
    /// </summary>
    /// <param name="unyt"></param>
    /// <param name="gold"></param>
    /// <returns></returns>
    private string SetTextSalaryGold(int unyt, int gold)
    {
        _salary = (unyt * gold);
        return SalaryText.text = (_salary * -1).ToString();
    }

    /// <summary>
    /// Итог заработка каждын _time секунд после всех вычетов
    /// </summary>
    /// <returns></returns>
    private string SetTextResultGold()
    {
        _result = _income - _salary;
        return ResultText.text = _result.ToString();
    }

    /// <summary>
    /// Логика работы таблицы доходы и раходы каждый _time
    /// </summary>
    public void TransactionsEveryTime()
    {
        _currentTime += UnityEngine.Time.deltaTime;
        DynamicImage.fillAmount = _currentTime / Time;
        SetTextIncomeGold(GameRecources.WorkerIncome, GameRecources.Workers);
        SetTextSalaryGold(GameRecources.WarriorSalary, GameRecources.Warriors);
        SetTextResultGold();
        if (_currentTime >= Time)
        {
            GameRecources.GetGold(_income);
            GameRecources.SpendGold(_salary);
            _currentTime = 0;
            DynamicImage.fillAmount = 0;
        }
    }

    private void Start()
    {
        _currentTime = 0;
        DynamicImage.fillAmount = 0;
    }

    private void Update()
    {
        TransactionsEveryTime();
    }

}
