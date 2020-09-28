using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Текстовая панель, все методы возвращают из класса GameRecources и обновляют текс
/// </summary>
public class ResourceTable : MonoBehaviour
{
    [Header("Ссылки на текстовые файлы (DinamicText)")]
    public Text GoldText;
    public Text WorkersText;
    public Text WarriorsText;
    public Text DeadWarriorsText;

    /// <summary>
    /// Обновить кол-во золота в текстовой панели для визуального отображения.
    /// </summary>
    /// <param name="Gold"></param>
    /// <returns></returns>
    public string SetTextInPanelGold(int Gold)
    {
        return this.GoldText.text = Gold.ToString();
    }
    /// <summary>
    /// Обновить кол-во рабочих в текстовой панели для визуального отображения.
    /// </summary>
    /// <param name="Worker"></param>
    /// <returns></returns>
    public string SetTextInPanelWorker(int Workers)
    {
        return WorkersText.text = Workers.ToString();
    }
    /// <summary>
    /// Обновить кол-во войнов в текстовой панели для визуального отображения.
    /// </summary>
    /// <param name="Warrior"></param>
    /// <returns></returns>
    public string SetTextInPanelWarrior(int Warriors)
    {
        return WarriorsText.text = Warriors.ToString();
    }
    /// <summary>
    ///  Обновить кол-во погибших войнов в текстовой панели для визуального отображения.
    /// </summary>
    /// <param name="DeadWarriors"></param>
    /// <returns></returns>
    public string SetTextInPanelDeadWarriors(int DeadWarriors)
    {
        return DeadWarriorsText.text = DeadWarriors.ToString();
    }

}
