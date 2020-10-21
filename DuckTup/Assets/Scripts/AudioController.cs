using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource MusikSource;
    public AudioSource Effect1Source;
    public AudioSource Effect2Source;
    public AudioSource Effect3Source;
    [Header("Музыка")]
    public AudioClip Forest;
    [Header("Эфекты")]
    public AudioClip PushDuck;
    public AudioClip KillTime;
    public AudioClip KillBad;

    void Start()
    {
        MusikForest();
    }

    #region Musik
    public void MusikForest()
    {
        MusikSource.clip = Forest;
        MusikSource.Play();
        MusikSource.loop = true;
    }
    #endregion

    #region Sound
    public void SoundPushDuck()
    {
        Effect1Source.clip = PushDuck;
        Effect1Source.Play();
    }
    public void SoundKillTime()
    {
        Effect2Source.clip = KillTime;
        Effect2Source.Play();
    }
    public void SoundKillBad()
    {
        Effect3Source.clip = KillBad;
        Effect3Source.Play();
    }
    #endregion


}
