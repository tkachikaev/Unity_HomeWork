using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SuperMan : MonoBehaviour
{
    public Vector3[] Points;
    public AudioClip Shot;
    public float Speed;
    public float Power = 1;
    private AudioSource _audioSource;
    [SerializeField]private int _n = 0;
    private bool _move = true;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = Shot;
        Boys[] AllBoys = FindObjectsOfType<Boys>();
        for (int i = 0; i < AllBoys.Length; i++)
        {
            Points[i] = AllBoys[i].transform.position;
        }
        transform.LookAt(Points[_n]);
    }

    void Update()
    {
        PalayerMove();
    }
    public void PalayerMove()
    {
        if (_move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[_n], Speed * Time.deltaTime);
            if (transform.position == Points[_n])
            {
                _n++;
                transform.LookAt(Points[_n]);
            }
            if (_n == Points.Length -1)
            {
                _move = false;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        //float distance = Vector3.Distance(transform.position, collision.transform.position);
        Vector3 direction = collision.transform.position - transform.position;
        collision.rigidbody.AddForce(direction.normalized * Power, ForceMode.Impulse); // *(Vector3.Distance(transform.position, collision.transform.position))
        _audioSource.Play();
    }
}
