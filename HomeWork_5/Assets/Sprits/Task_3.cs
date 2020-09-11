using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Task_3 : MonoBehaviour
{
    [SerializeField] InputField InputField = null;
    public Text taskWorkText = null;

    private void Start()
    {
        InputField.text = "4";
    }

    /// <summary>
    /// Вычисляем Факториал
    /// </summary>
    public void Factorial()
    {
        int result = 1;
        int number = Int32.Parse(InputField.text);
        taskWorkText.fontSize = 56;
        if (InputField.text == "")
        {
            Start();
        }

        if ( number<0 || number > 12)
        {
            taskWorkText.fontSize = 35;
            taskWorkText.text = $"Не меньше 0 и не более 12";
        }
        else
        {
            for (int i = result; i <= number; i++)
            {
                result *= i;
            }
            taskWorkText.text = $"{result}";
        }
    }

}
