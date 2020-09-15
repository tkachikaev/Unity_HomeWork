using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public SoundAndMusik sound;
    public Resource res;
    public TextResources text;
    public ButtonAndPanel bap;

    private void Start()
    {
        sound.OnSoundVillage();
    }
    private void Update()
    {
        bap.RaidBarTimer(true);
        res.WorkerSpawnGold();
        res.WarriorSalary();
    }


}
