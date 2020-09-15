using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
/// <summary>
/// Здесь хранятся все ресурсы игрока
/// </summary>
public class Resource : MonoBehaviour
{
    TextResources text;

    #region Resourse
    public int gold = 20;
    public int warriors = 1;
    public int workers = 0;
    public int looses = 0;

    public int buyWorker = 20; //Цена
    public int buyWarrior = 40; //Цена

    private int workersProfitGold = 5;
    private int warriorsSalary = 2;
    [SerializeField] private float profitTime = 1f;
    [SerializeField] private float currentProfitTime;
    #endregion

    private void Start()
    {
        
        text = GetComponent<TextResources>();
        text.goldText.text = (gold).ToString();

    }

    /// <summary>
    /// Покупка и запись
    /// </summary>
    public void BuyWorker()
    {
        gold -= buyWorker;
        text.SetGoldText(gold.ToString());
    }

    /// <summary>
    /// Покупка и запись
    /// </summary>
    public void BuyWarrior()
    {
        gold -= buyWarrior;
        text.SetGoldText(gold.ToString());
    }

    /// <summary>
    /// Каждый цикл работники добывают золото.
    /// </summary>
    public void WorkerSpawnGold()
    {
        int tempGold = workers * workersProfitGold;
        currentProfitTime -= Time.deltaTime;
        if (currentProfitTime <= 0)
        {
            gold += tempGold;
            text.SetGoldText(gold.ToString());
            currentProfitTime = profitTime;
        }
    }
    /// <summary>
    /// Каждый цыкл выплачивается золото войнам
    /// </summary>
    public void WarriorSalary()
    {
        int tempSalary = warriors * warriorsSalary;
        currentProfitTime -= Time.deltaTime;
        if (currentProfitTime <= 0)
        {
            if (gold<tempSalary)
            {
                gold = Mathf.Min(tempSalary, gold);
            }
            else
            {
                gold -= tempSalary;
            }
            text.SetGoldText(gold.ToString());
            currentProfitTime = profitTime;
        }
    }
}
