using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAndPanel : MonoBehaviour
{
    public SoundAndMusik sound;
    public Resource res;
    public TextResources text;

    public Image imageButtonWorker;
    public float coolDownWorker = 10f;
    private float currentTimeWorker;
    private bool timeWorker = false; //Можно нажать на кнопку или нет

    public Image imageButtonWarrior;
    public float coolDownWarrior = 10f;
    private float currentTimeWarrior;
    private bool timeWarrior = false; //Можно нажать на кнопку или нет

    public Image imageRaidLine;
    public float raidTime = 40f;
    private float currentRaidTime;


    private void Start()
    {
        currentTimeWorker = coolDownWorker;
        currentTimeWarrior = coolDownWarrior;
        currentRaidTime = raidTime;
    }

    /// <summary>
    /// Нажатие кнопки с последующей покупкой Рабочего
    /// </summary>
    public void OnClickBuyWorker()
    {
        if (res.gold >= res.buyWorker && timeWorker == false)
        {
            OnClickButtonWorker();
            res.BuyWorker();
        }
        else if(res.gold < res.buyWorker)
        {
            text.cooldownWorker.text = $"Надо {res.buyWorker} золота";
            
        }
    }

    /// <summary>
    /// Нажатие кнопки с последующей покупкой Война
    /// </summary>
    public void OnClickBuyWarrior()
    {
        if (res.gold >= res.buyWarrior && timeWarrior == false)
        {
            OnClickButtonWarrior();
            res.BuyWarrior();
        }
        else if (res.gold < res.buyWarrior)
        {
            text.cooldownWarrior.text = $"Надо {res.buyWarrior} золота";

        }
    }

    /// <summary>
    /// Логика работы кнопки
    /// </summary>
    private void OnClickButtonWorker()
    {
        timeWorker = true;
        currentTimeWorker -= Time.deltaTime;
        imageButtonWorker.fillAmount = currentTimeWorker / coolDownWorker;
        text.SetCooldownWorkerText(Mathf.Round(currentTimeWorker).ToString());
        if (currentTimeWorker <= 0)
        {
            timeWorker = false;
            currentTimeWorker = coolDownWorker;
            imageButtonWorker.fillAmount = 1;
            sound.CreateWorker();
            text.SetCooldownWorkerText("Обучить\nРабочего");
            text.SetAddWorkersText();
        }
    }

    /// <summary>
    /// Логика работы кнопки
    /// </summary>
    private void OnClickButtonWarrior()
    {
        timeWarrior = true;
        currentTimeWarrior -= Time.deltaTime;
        imageButtonWarrior.fillAmount = currentTimeWarrior / coolDownWarrior;
        text.SetCooldownWarriorText(Mathf.Round(currentTimeWarrior).ToString());
        if (currentTimeWarrior <=0)
        {
            timeWarrior = false;
            currentTimeWarrior = coolDownWarrior;
            imageButtonWarrior.fillAmount = 1;
            sound.CreateWarrior();
            text.SetCooldownWarriorText("Обучить\nВойна");
            text.SetAddWarriorsText();
        }
    }

    /// <summary>
    /// Запускает полоску и время до аттаки
    /// </summary>
    public void RaidBarTimer(bool OnOff)
    {
        if (OnOff)
        {
            currentRaidTime -= Time.deltaTime;
            imageRaidLine.fillAmount = currentRaidTime / raidTime;
            text.SetRaidBarTimerText(Mathf.Round(currentRaidTime).ToString());
            if (currentRaidTime <= 0) 
            {
                raidTime += 5; // Кажадая атака дает + 5 ко времени.
                currentRaidTime = raidTime;
            } 
        }
        
    }
    private void Update()
    {
        if (timeWorker) OnClickButtonWorker();
        if (timeWarrior) OnClickButtonWarrior();
    }
}
