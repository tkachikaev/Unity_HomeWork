using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusik : MonoBehaviour
{
    public AudioSource SoundTheam = null;
    public AudioSource EffectTheame = null;
    public AudioSource CreatePerson = null;
    public AudioSource EffectRaid = null;
    public AudioClip ClipVillage = null;
    public AudioClip ClipButton = null;
    public AudioClip ClipCreateWorker = null;
    public AudioClip ClipCreateWarrior = null;
    public AudioClip ClipRaid = null;

    private void Start()
    {
        SoundVillage();
    }
    /// <summary>
    /// Фоновая музыка города
    /// </summary>
    public void SoundVillage()
    {
        SoundTheam.clip = ClipVillage;
        SoundTheam.Play();
        SoundTheam.loop = true;
    }
    /// <summary>
    /// Звук кнопки
    /// </summary>
    public void SoundButton()
    {
        EffectTheame.clip = ClipButton;
        EffectTheame.Play();
        EffectTheame.loop = false;
    }
    /// <summary>
    /// Звук создания работника
    /// </summary>
    public void SoundCreateWorker()
    {
        CreatePerson.clip = ClipCreateWorker;
        CreatePerson.Play();
    }
    /// <summary>
    /// Звук создания война
    /// </summary>
    public void SoundCreateWarrior()
    {
        CreatePerson.clip = ClipCreateWarrior;
        CreatePerson.Play();
    }
    /// <summary>
    /// Нападение на деревню
    /// </summary>
    public void SoundRaid()
    {
        EffectRaid.clip = ClipRaid;
        EffectRaid.Play();
    }
}
