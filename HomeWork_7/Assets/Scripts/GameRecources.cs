using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хранит в себе настройки такие как золото, рабочие, войны смерти, случай победы и поражения.
/// </summary>
public class GameRecources : MonoBehaviour
{
    public GameStatistics GameStatistics;
    public ResourceTable ResourceTable;
    public EndOfTheGame EndOfTheGame;
    public int Gold;
    public int Workers;
    public int Warriors;
    public int DeadWarriors;
    public int GoldForVictory = 10_000;
    [Header("Параметры рабочего")]
    public int WorkerPrice = 10;
    public int WorkerIncome = 5;
    [Header("Параметры Война")]
    public int WarriorPrice = 20;
    public int WarriorSalary = 2;

    /// <summary>
    /// Добавить золото
    /// </summary>
    /// <param name="gold"></param>
    /// <returns></returns>
    public int GetGold(int gold)
    {
        GameStatistics.AddToMaximumGold(gold);
        Gold += gold;
        ResourceTable.SetTextInPanelGold(Gold);
        if (Gold >= GoldForVictory) EndOfTheGame.GameWin();
        return Gold;
    }
    /// <summary>
    /// Отнять золото
    /// </summary>
    /// <param name="gold"></param>
    /// <returns></returns>
    public int SpendGold(int gold)
    {
        Gold -= gold;
        ResourceTable.SetTextInPanelGold(Gold);
        GameStatistics.AddToMaximumGoldSpent(gold);
        if (Gold < 0) EndOfTheGame.GameLoos();
        return Gold;
    }
    /// <summary>
    /// Добавить рабочего
    /// </summary>
    public void GetWorker()
    {
        Workers++;
        ResourceTable.SetTextInPanelWorker(Workers);
    }
    /// <summary>
    /// Добавить Война
    /// </summary>
    public void GetWarrior()
    {
        Warriors++;
        ResourceTable.SetTextInPanelWarrior(Warriors);
    }
    /// <summary>
    /// Удалить война
    /// </summary>
    /// <param name="Killer"></param>
    /// <returns></returns>
    public int KillWarrior(int Killer)
    {
        if (Warriors < Killer)
        {
            ResourceTable.SetTextInPanelDeadWarriors(DeadWarriors);
            GameStatistics.AddToMaximumLosses(Warriors);
            Warriors = 0;
            EndOfTheGame.GameLoos();
        }
        else
        {
            Warriors -= Killer;
            DeadWarriors += Killer;
            ResourceTable.SetTextInPanelWarrior(Warriors);
            ResourceTable.SetTextInPanelDeadWarriors(DeadWarriors);
            GameStatistics.AddToMaximumLosses(DeadWarriors);
        }
        return Warriors;
    }

    private void Start()
    {
        ResourceTable.SetTextInPanelGold(Gold);
        ResourceTable.SetTextInPanelWorker(Workers);
        ResourceTable.SetTextInPanelWarrior(Warriors);
        ResourceTable.SetTextInPanelDeadWarriors(DeadWarriors);
    }

}
