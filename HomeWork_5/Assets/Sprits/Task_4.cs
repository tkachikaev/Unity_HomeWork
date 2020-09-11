using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task_4 : MonoBehaviour
{
    [SerializeField] private InputField Num1 = null;
    [SerializeField] private InputField Num2 = null;
    [SerializeField] private InputField NumberMax = null;
    public Text textWork = null;
    private int summ = 0;

    private void Start()
    {
        Num1.text = (3).ToString();
        Num2.text = (5).ToString();
        NumberMax.text = (1000).ToString();
    }

    public void MultiplesNum()
    {
        summ = 0;
        textWork.text = "";
        int max = Int32.Parse(NumberMax.text);
        int num1 = Int32.Parse(Num1.text);
        int num2 = Int32.Parse(Num2.text);


        for (int i = 1; i < max; i++)
        {
            if (i % num1 == 0 || i % num2 == 0)
            {
                summ += i;
            }
        }
        textWork.text = $"{summ}";
    }
}
