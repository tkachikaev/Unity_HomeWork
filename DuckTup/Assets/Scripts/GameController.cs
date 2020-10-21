using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UIController UIController;
    public SpawnController SpawnController;
    public AudioController AudioController;
    public Resources Resources;
    [Header("Статические параметры игры")]
    public float Timer;
    public int ScorePerDuck;
    public float TimePerDuck;
    public float TimeTakeMonster;
    [Header("Динамические параметры игры")]
    [SerializeField] private float _currentTime;

    private void Start()
    {
        _currentTime = Timer;
    }

    private void Update()
    {
        OnClickDuck();
        TimerGame();
    }
    /// <summary>
    /// Проверка поподания при нажатии, 
    /// </summary>
    public void OnClickDuck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Duck1"))
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                        AudioController.SoundPushDuck();
                        Resources.AddScore(ScorePerDuck);
                    }
                    else Debug.Log("Уже убит!");
                }

                if (hit.collider.gameObject.CompareTag("DuckTime"))
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                        _currentTime += TimePerDuck;
                        AudioController.SoundKillTime();
                    }
                    else Debug.Log("Уже убит!");
                }

                if (hit.collider.gameObject.CompareTag("MonsterTime"))
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.5f;
                        _currentTime -= TimeTakeMonster;
                        AudioController.SoundKillBad();
                    }
                    else Debug.Log("Уже убит!");
                }

                if (hit.collider.gameObject.CompareTag("DuckDouble"))
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5f;
                        Resources.AddScore(ScorePerDuck * 2);
                        AudioController.SoundPushDuck();
                    }
                    else Debug.Log("Уже убит!");
                }
            }
            else Debug.Log("Miss");
        }
    }

    /// <summary>
    /// Игровой таймер
    /// </summary>
    public void TimerGame()
    {
        if (_currentTime >= 0 )
        {
            _currentTime -= Time.deltaTime;
            UIController.SetTimerText(_currentTime);
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        UIController.EnableUILost();
        SpawnController.StopSpawnDuck();
    }
}
