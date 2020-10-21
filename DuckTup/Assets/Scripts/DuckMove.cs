using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DuckMove : MonoBehaviour
{
    public float Speed;
    private Vector2 pos; //Текущая позиция
    private bool _derectionRight; //Направление в право true, в лево false.
    [SerializeField] private float _maxYDestroy = 20;
    [SerializeField] private float _minYDestroy = -20;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprireRendererFlip;
    private Animator _animator;

    private void Start()
    {
        #region Получаем компоненты
        _sprireRendererFlip = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        #endregion

        if (transform.position.x <= -10) _derectionRight = true;
        if (transform.position.x >= 10)
        {
            _derectionRight = false; 
            Speed *= -1;
        } 
    }

    private void Update()
    {
        DuckDirectionMove(_derectionRight);
        AnimationDieOn();
        DestroyDuck();
    }

    /// <summary>
    /// Направление полета и движение
    /// </summary>
    /// <param name="direction"></param>
    public void DuckDirectionMove(bool direction)
    {
        if (direction == true) //Полет в право
        {
            pos = transform.position;
            pos.x += Speed * Time.deltaTime;
            transform.position = pos;
            if (transform.position.x <= 0)
            {
                _sprireRendererFlip.flipX = true;

            }
        }
        if (direction == false) //Полет в лево
        {
            pos = transform.position;
            pos.x += Speed * Time.deltaTime;
            transform.position = pos;
            _sprireRendererFlip.flipX = false;
        }
    }

    /// <summary>
    /// Удаляет птицу по осям  Х У
    /// </summary>
    public void DestroyDuck()
    {
        if (transform.position.y <= -10 || transform.position.x <= -15 || transform.position.x >=15)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.x >= _maxYDestroy || transform.position.x <= _minYDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// Включает анимацию смерти
    /// </summary>
    public void AnimationDieOn()
    {
        if (_rigidbody2D.gravityScale > 0)
        {
            _animator.SetBool("Alive", false);
        }
        if(_rigidbody2D.gravityScale < 0)
        {
            if (_rigidbody2D.gameObject.CompareTag("MonsterTime"))
            {
                _animator.SetBool("Attack", true);
            } 
        }
    }
    /// <summary>
    /// Конец игры, птицы улетают
    /// </summary>
    public void GameLostDuckFly()
    {
        if (_rigidbody2D.gravityScale == 0)
        {
            _rigidbody2D.gravityScale = UnityEngine.Random.Range(-1, -3);
        }
    }
}
