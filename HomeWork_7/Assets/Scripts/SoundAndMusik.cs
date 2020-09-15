using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusik : MonoBehaviour
{
    #region Music and Sound
    public AudioSource soundTheam = null;
    public AudioSource effectTheame = null;
    public AudioSource createPerson = null;
    public AudioClip soundVillage = null;
    public AudioClip soundBattle = null;
    public AudioClip soundButton = null;
    public AudioClip soundCreateWorker = null;
    public AudioClip SoundCreateWarrior = null;
    #endregion

    /// <summary>
    /// Фоновая музыка города
    /// </summary>
    public void OnSoundVillage()
    {
        soundTheam.clip = soundVillage;
        soundTheam.Play();
        soundTheam.loop = true;
    }
    /// <summary>
    /// Фоновая музыка биты
    /// </summary>
    public void OnSoundBattle()
    {
        soundTheam.clip = soundBattle;
        soundTheam.Play();
    }
    /// <summary>
    /// Звук кнопки
    /// </summary>
    public void OnSoundButton()
    {
        effectTheame.clip = soundButton;
        effectTheame.Play();
        effectTheame.loop = false;
    }
    /// <summary>
    /// Звук создания работника
    /// </summary>
    public void CreateWorker()
    {
        createPerson.clip = soundCreateWorker;
        createPerson.Play();
    }
    /// <summary>
    /// Звук создания война
    /// </summary>
    public void CreateWarrior()
    {
        createPerson.clip = SoundCreateWarrior;
        createPerson.Play();
    }
}
