using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float Time = 3f;
    public float ExplosionPower;
    public float Radius;
    private bool _activeTimer;

    private void Start()
    {
        _activeTimer = true;

    }

    private void Update()
    {
        if(_activeTimer) Time -= UnityEngine.Time.deltaTime;
        if (Time <= 0 && _activeTimer == true)
        {
            Explosion();
            _activeTimer = false;
        }
    }

    public void Explosion()
    {
        Rigidbody[] obj = FindObjectsOfType<Rigidbody>();

        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].AddExplosionForce(ExplosionPower, transform.position, Radius);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
