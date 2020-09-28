using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Панель во время нажатия паузы и окончании игры,
/// в классе хранятся перемнные с максимально достигнутыми значениями.
/// </summary>
public class GameStatistics: MonoBehaviour
{
    [Header("Ссылки на текстовые файлы (DinamicText)")]
    public Text TimeIsNow;
    public Text MaxGold;
    public Text MaxGoldSpent;
    public Text MaxDeadWarriors;
    public Text MaxRaidWave;
    private int _goldMax;
    private int _goldSpentMax;
    private int _deadWarriors;
    private int _raidWaveMax;
    private DateTime nowTime;

    /// <summary>
    /// Выводим текущее время на экран для красоты
    /// </summary>
    private void WorldTime()
    {
        nowTime = DateTime.Now;
        TimeIsNow.text = nowTime.ToString("HHч mmм ssс");
    }

    /// <summary>
    /// Доавляем к максимальному количеству всего добытого золата
    /// </summary>
    /// <param name="Gold">Золото</param>
    public string AddToMaximumGold(int Gold)
    {
        _goldMax += Gold;
        return MaxGold.text = _goldMax.ToString();
    }

    /// <summary>
    /// Доавляем к максимальному количеству всех потраченных денег
    /// </summary>
    /// <param name="GoldSpent"></param>
    public string AddToMaximumGoldSpent(int GoldSpent)
    {
        _goldSpentMax += GoldSpent;
        return MaxGoldSpent.text = _goldSpentMax.ToString();
    }

    /// <summary>
    /// Добавляем к максимальному кол-ву потерянных войнов
    /// </summary>
    /// <param name="Losses"></param>
    public string AddToMaximumLosses(int Losses)
    {
        _deadWarriors = Losses;
        return MaxDeadWarriors.text = _deadWarriors.ToString();
    }

    /// <summary>
    /// Максимальное кол-во отраженных волн
    /// </summary>
    /// <param name="Raid"></param>
    public string AddToMaximumRaid(int Raid)
    {
        _raidWaveMax = Raid;
        return MaxRaidWave.text = _raidWaveMax.ToString();
    }

    private void Update()
    {
        WorldTime();
    }
}
