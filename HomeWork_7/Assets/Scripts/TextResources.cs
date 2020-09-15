using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextResources : MonoBehaviour
{
    Resource res;

    #region Link
    public Text raidBarText = null;
    public Text goldText = null;
    public Text warriorsText = null;
    public Text workersText = null;
    public Text lossesText = null;
    public Text cooldownWorker = null;
    public Text cooldownWarrior = null;
    #endregion

    private void Start()
    {
        res = GetComponent<Resource>();
    }

    /// <summary>
    /// Записать статус золота в текст
    /// </summary>
    /// <param name="gold"></param>
    public void SetGoldText(string gold)
    {
        goldText.text = gold.ToString();
    }
    /// <summary>
    /// Записывает кол-во работников в панель
    /// </summary>
    public void SetAddWorkersText()
    {
        res.workers++;
        workersText.text = res.workers.ToString();
    }
    /// <summary>
    /// Записывает кол-во войнов в панель
    /// </summary>
    public void SetAddWarriorsText()
    {
        res.warriors++;
        warriorsText.text = res.warriors.ToString();
    }
    /// <summary>
    /// Bar нападния, запись.
    /// </summary>
    /// <param name="timer"></param>
    public void SetRaidBarTimerText(string timer)
    {
        raidBarText.text = timer.ToString();
    }

    #region Подсказки кнопок, маленькая менюшка
    public void SetCooldownWorkerText(string timer)
    {
        cooldownWorker.text = timer;
    }
    public void SetCooldownWarriorText(string timer)
    {
        cooldownWarrior.text = timer;
    }
    #endregion
}
