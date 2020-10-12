using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPoint : MonoBehaviour
{
    public GameObject Player;
    public Vector3[] Points;
    public float Speed;
    public bool Forward = true;
    public int N = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Forward == true)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, Points[N], Speed * Time.deltaTime);
            CheckPoind();
            if (N == Points.Length - 1)
            {
                Forward = false;
            }
        }
        if (Forward == false)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, Points[N], Speed * Time.deltaTime);
            CheckPoind();
            if (N == 0)
            {
                Forward = true;
            }
        }
    }

    private void CheckPoind()
    {
        if (Forward == true && Player.transform.position == Points[N])
        {
            N++;
            Player.transform.LookAt(Points[N]);

        }
        if (Forward == false && Player.transform.position == Points[N])
        {
            N--;
            Player.transform.LookAt(Points[N]);
        }
    }
}
