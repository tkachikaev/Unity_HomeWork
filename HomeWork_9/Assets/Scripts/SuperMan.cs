using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SuperMan : MonoBehaviour
{
    public GameObject[] Points;
    public AudioClip Shot;
    public float Speed;
    public float Power = 1;
    private AudioSource _audioSource;
    private int _n = 0;
    private bool _forward = true;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = Shot;
    }

    void Update()
    {
        PalayerMove();
    }
    public void PalayerMove()
    {
        if (_forward == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[_n].transform.position, Speed * Time.deltaTime);
            if (transform.position == Points[_n].transform.position)
            {
                _n++;
            }
            if (_n == Points.Length -1)
            {
                _forward = false;
            }
        }
        if (_forward == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[_n].transform.position, Speed * Time.deltaTime);
            if (transform.position == Points[_n].transform.position)
            {
                _n--;
            }
            if (_n == 0)
            {
                _forward = true;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BadBoy")
        {
            float distance = Vector3.Distance(transform.position, collision.transform.position);
            Vector3 direction = collision.transform.position - transform.position;
            collision.rigidbody.AddForce(direction.normalized * Power *(Vector3.Distance(transform.position, collision.transform.position)), ForceMode.Impulse);
            _audioSource.Play();
            if (_n == Points.Length - 1)
            {
                _forward = false;
            }
            _n++; // Когда пнем, меняем цель
        }
    }
}
