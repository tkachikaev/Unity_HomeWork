using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    [Header("Префабы уток")]
    public GameObject[] Ducks;
    [Header("Настройки спауна уток")]
    public float TimeSpawnDuck; // Время создания уток
    public float TimeSecondSpawnDucks = 1f; // Время создания остальных уток (Шанс)
    public int ChanceSpawnDuckTime;
    public int ChanceSpawnMonsterTime;
    public int ChanceSpawnDuckDouble;
    [Header("Спаунеры")]
    public Vector2 PositionRightSpawn;
    public Vector2 PositionLeftSpawn;
    [SerializeField]private float _maxY = 4.1f;
    [SerializeField]private float _minY = 4.2f;
    private float _timerSpawn;
    private bool _activeSpawn = true;
    private float _curentTime;

    private void Update()
    {
        if (_activeSpawn)
        {
            SpawnDuck1();
            TimeSpawnDuckOneSecond();
        }
    }

    /// <summary>
    /// Рандомное значение по оси Y для левого спауна
    /// </summary>
    public Vector2 SpawnerLeftRandomPosition()
    {
        PositionLeftSpawn.y = UnityEngine.Random.Range(_minY, _maxY);
        return PositionLeftSpawn;
    }
    /// <summary>
    /// Рандомное значение по оси Y для правого спауна
    /// </summary>
    public Vector2 SpawnerRightRandomPosition()
    {
        PositionRightSpawn.y = UnityEngine.Random.Range(_minY, _maxY);
        return PositionRightSpawn;
    }

    /// <summary>
    /// Создание первого объекта
    /// </summary>
    public void SpawnDuck1()
    {
        _timerSpawn -= Time.deltaTime;
        if (_timerSpawn <= 0)
        {
            Instantiate<GameObject>(Ducks[0]);
            Ducks[0].transform.position = SpawnerLeftRandomPosition();
            Instantiate<GameObject>(Ducks[0]);
            Ducks[0].transform.position = SpawnerRightRandomPosition();
            _timerSpawn = TimeSpawnDuck;
        }
    }

    /// <summary>
    /// Создание второго объекта
    /// </summary>
    public void SpawnDuckTime()
    {
        int chanceSpawn = (UnityEngine.Random.Range(1,101));
        if (chanceSpawn <= ChanceSpawnDuckTime)
        {
            #region Создаем птицу в рандомной стороне
            int sideSpawn = UnityEngine.Random.Range(1, 3);
            switch (sideSpawn)
            {
                case 1:
                    Instantiate<GameObject>(Ducks[1]);
                    Ducks[1].transform.position = SpawnerLeftRandomPosition();
                    break;
                case 2:
                    Instantiate<GameObject>(Ducks[1]);
                    Ducks[1].transform.position = SpawnerRightRandomPosition();
                    break;
                default:
                    Debug.Log("Error sapwn Duck Time");
                    break;
            }
            #endregion
        }
    }

    /// <summary>
    /// Создание третьего объекта
    /// </summary>
    public void SpawnMonsterTime()
    {
        int chanceSpawn = (UnityEngine.Random.Range(1, 101));
        if (chanceSpawn <= ChanceSpawnMonsterTime)
        {
            #region Создаем монстра в рандомной стороне
            int sideSpawn = UnityEngine.Random.Range(1, 3);
            switch (sideSpawn)
            {
                case 1:
                    Instantiate<GameObject>(Ducks[2]);
                    Ducks[2].transform.position = SpawnerLeftRandomPosition();
                    break;
                case 2:
                    Instantiate<GameObject>(Ducks[2]);
                    Ducks[2].transform.position = SpawnerRightRandomPosition();
                    break;
                default:
                    Debug.Log("Error spawn Monster Time");
                    break;
            }
            #endregion
        }
    }

    /// <summary>
    /// Создание четвертого объекта
    /// </summary>
    public void SpawnDuckDouble()
    {
        int chanceSpawn = (UnityEngine.Random.Range(1, 101));
        if (chanceSpawn <= ChanceSpawnDuckDouble)
        {
            #region Создаем птицу в рандомной стороне
            int sideSpawn = UnityEngine.Random.Range(1, 3);
            switch (sideSpawn)
            {
                case 1:
                    Instantiate<GameObject>(Ducks[3]);
                    Ducks[3].transform.position = SpawnerLeftRandomPosition();
                    break;
                case 2:
                    Instantiate<GameObject>(Ducks[3]);
                    Ducks[3].transform.position = SpawnerRightRandomPosition();
                    break;
                default:
                    Debug.Log("Error sapwn Duck Time");
                    break;
            }
            #endregion
        }
    }

    /// <summary>
    /// Счетчик создания птиц имеющих шанс
    /// </summary>
    public void TimeSpawnDuckOneSecond()
    {
        _curentTime -= Time.deltaTime;
        if (_curentTime <= 0)
        {
            SpawnMonsterTime();
            SpawnDuckTime();
            SpawnDuckDouble();
            _curentTime = TimeSecondSpawnDucks;
        }
    }

    public void StopSpawnDuck()
    {
        _activeSpawn = false;
        DuckMove[] Ducks = FindObjectsOfType<DuckMove>();
        foreach (DuckMove duck in Ducks)
        {
            duck.GetComponent<DuckMove>().GameLostDuckFly();
        }
    }
}
