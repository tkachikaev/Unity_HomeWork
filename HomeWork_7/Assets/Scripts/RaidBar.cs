using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Метод отвечающий за нападение
/// </summary>
public class RaidBar : MonoBehaviour
{
    public GameRecources GameRecources;
    public ResourceTable ResourceTable;
    public GameStatistics GameStatistics;
    public SoundAndMusik SoundAndMusik;
    [Header("Ссылки на текстовые файлы (DinamicText)")]
    public Text TimerText;
    public Text WaveInformation;
    public Image DynamicImage;
    [Header("Настройки нападений")]
    public float TimeBeforeTheAttack = 30f;
    private float _currentTime;
    private int _attackers = 0; // Атакующие юниты
    private int _wave = 1; // Волны

    private void Start()
    {
        _currentTime = TimeBeforeTheAttack;
        SetTextIfoWave();
    }

    private void Update()
    {
        RaidTimeGo();
    }

    /// <summary>
    /// Полоска таймера, динамичная картинка.
    /// </summary>
    public void RaidTimeGo()
    {
        _currentTime -= Time.deltaTime;
        DynamicImage.fillAmount = _currentTime / TimeBeforeTheAttack;
        if (Mathf.Round(_currentTime) == 4)
        {
            SoundAndMusik.SoundRaid();
        }
        RaidTimerText();
        if (_currentTime <= 0)
        {
            RaidSoldersAttack();
            _currentTime = TimeBeforeTheAttack;
            SetTextIfoWave();
        }
    }
    /// <summary>
    /// Числовой таймер указывающий время до нападения, записывается в текст.
    /// </summary>
    public void RaidTimerText()
    {
        TimerText.text = Mathf.Round(_currentTime).ToString();
        //ResourceTable.SetTextInPanelWarrior();
    }

    /// <summary>
    /// Усиляет каждую последующию волну кол-вом нападающих и (увеличивает время до нападения).
    /// </summary>
    public void RaidSoldersAttack()
    {
        GameRecources.KillWarrior(_attackers);
        GameStatistics.AddToMaximumRaid(_wave);
        if (_attackers != 10) // Больше 10 не должно нападать
        {
            _attackers += 2;
        }
        _wave++;
    }
    /// <summary>
    /// Показывает номер волны и кол-во нападающих в следующей волне.
    /// </summary>
    /// <returns></returns>
    public string SetTextIfoWave()
    {
        return WaveInformation.text = $"Волна: {_wave} Врагов: {_attackers}";
    }
}
