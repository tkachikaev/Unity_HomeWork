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
    [SerializeField] private string question6 = "220"; //Сколько вольт
    [SerializeField] private string question7 = "2020"; //В каком году добрался ковид
    [SerializeField] private string question8 = "10"; //сколько пальцев на обеих ногах
    [SerializeField] private string question9 = "1"; // Сколькоо глаз у одноглазово пирата
    [SerializeField] private string question10 = "вторник"; //Какой день идет после понедельника
    #endregion

    #region Счетчик
    private int yes = 0;
    private int no = 0;
    #endregion



    public void onClickQuestion1(InputField inputFild)
    {
        count.text += $"| 1-";
        if (inputFild.text.Equals(question1.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else 
        {
            count.text += "Ошибка.";
            no++;
        } 
    }

    public void onClickQuestion2(InputField inputFild)
    {
        count.text += $"| 2-";
        if (inputFild.text.Equals(question2.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion3(InputField inputFild)
    {
        count.text += $"| 3-";
        if (inputFild.text.Equals(question3.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion4(InputField inputFild)
    {
        count.text += $"| 4-";
        if (inputFild.text.Equals(question4.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion5(InputField inputFild)
    {
        count.text += $"| 5-";
        if (inputFild.text.Equals(question5.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion6(InputField inputFild)
    {
        count.text += $"\n| 6-";
        if (inputFild.text.Equals(question6.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion7(InputField inputFild)
    {
        count.text += $"| 7-";
        if (inputFild.text.Equals(question7.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion8(InputField inputFild)
    {
        count.text += $"| 8-";
        if (inputFild.text.Equals(question8.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion9(InputField inputFild)
    {
        count.text += $"| 9-";
        if (inputFild.text.Equals(question9.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void onClickQuestion10(InputField inputFild)
    {
        count.text += $"| 10-";
        if (inputFild.text.Equals(question10.ToString()))
        {
            count.text += $"Верно.";
            yes++;
        }
        else
        {
            count.text += "Ошибка.";
            no++;
        }
    }

    public void winLose()
    {
        count.text += $"\n\nИтог:\nВерно: {yes}\nНе верно: {no}";
    }

    public void ResetCount()
    {
        count.text = "";
        yes = 0;
        no = 0;
    }

}
