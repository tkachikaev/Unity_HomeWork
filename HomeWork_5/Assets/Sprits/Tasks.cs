using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    [SerializeField] private InputField inputFieldMin = null; //Поставил null из-за того что 
    [SerializeField] private InputField inputFieldMax = null; //Unity выбрасывает предупреждения.

    public Text taskWorkText = null;


    private void Start()
    {

    }   

    /// <summary>
    /// Задание 1. Выводим четные числа
    /// </summary>
    public void Task1()
    {
        //Проверка на пустоту
        if (inputFieldMin.text == "" || inputFieldMax.text == "")
        {
            inputFieldMin.text = (1).ToString();
            inputFieldMax.text = (10).ToString();
        }
        int numMin = Int32.Parse(inputFieldMin.text);
        int numMax = Int32.Parse(inputFieldMax.text);

        //Проверка на корректность ввода
        if (numMin < -100)
        {
            inputFieldMin.text = (-100).ToString();
            numMin = -100;
        }
        if (numMax > 100)
        {
            inputFieldMax.text = (100).ToString();
            numMax = 100;
        }

        if (numMin >= numMax)
        {
            taskWorkText.text = ($"Минимальное число не может быть больше или равно максимальному числу!");
        }
        else
        {
            taskWorkText.text = "Диапозон чисел:\n";
            for (int i = numMin; i < numMax; i++)
            {
                if (i % 2 == 0)
                {
                    //if (i == 0) continue; // На ноль делить нельзя, но лучше оставлю.

                    taskWorkText.text += ($"{i} ");

                }
            }
        }
    }

    public void Task2()
    {
        
    }
}
