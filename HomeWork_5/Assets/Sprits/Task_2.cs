using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Task_2 : MonoBehaviour
{
    public Text taskWordText = null;

    public void PrintTable()
    {

        taskWordText.text = "";
        for (int i = 1; i < 10; i++)
        {
            /* Пришлось вывести 10х в отдельный столбец,
             * Иначе строки разлетаются, а так вся таблица на одном экране
             */
            for (int j = 1; j <= 10; j++)
            {
                taskWordText.text += $"{j}x{i}={j * i}\t\t";
            }
            taskWordText.text += "\n";
        }

    }
}
