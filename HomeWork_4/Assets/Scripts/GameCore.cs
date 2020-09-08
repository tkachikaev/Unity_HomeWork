using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Transactions;


public class GameCore : MonoBehaviour
{
    // Ссылка на счетчик
    [SerializeField] private Text count;

    #region Ответы на вопросы
    [SerializeField] private string question1 = "1945";
    [SerializeField] private string question2 = "4";
    [SerializeField] private string question3 = "белый";
    [SerializeField] private string question4 = "200";
    [SerializeField] private string question5 = "android";
    #endregion

    #region Счетчик
    private int yes = 0;
    private int no = 0;
    #endregion

    public void onClickQuestion1(InputField inputFild)
    {
        if (inputFild.text.Equals(question1.ToString())) yes++;
        else no++;
    }

    public void onClickQuestion2(InputField inputFild)
    {
        if (inputFild.text.Equals(question2.ToString())) yes++;
        else no++;
    }

    public void onClickQuestion3(InputField inputFild)
    {
        if (inputFild.text.Equals(question3.ToString())) yes++;
        else no++;
    }

    public void onClickQuestion4(InputField inputFild)
    {
        if (inputFild.text.Equals(question4.ToString())) yes++;
        else no++;
    }

    public void onClickQuestion5(InputField inputFild)
    {
        if (inputFild.text.Equals(question5.ToString())) yes++;
        else no++;
    }

    public void winLose()
    {
        count.text = $"Верно: {yes}\nНе верно: {no}";
    }

    public void ResetCount()
    {
        yes = 0;
        no = 0;
    }
}
