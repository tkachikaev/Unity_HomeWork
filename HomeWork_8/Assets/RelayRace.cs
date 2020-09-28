using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class RelayRace : MonoBehaviour
{
    public GameObject[] Runners;
    public float Speed;
    public bool forward = true;
    public float PassDistance = 5f;
    public int N;

    private void Start()
    {
        N = 0;
    }

    void Update()
    {
        RunnersMove();
    }

    public void RunnersMove()
    {
        if (forward == true)
        {
            if (N == Runners.Length - 1)
            {
                Runners[N].transform.position = Vector3.MoveTowards(Runners[N].transform.position,
                                                                    Runners[0].transform.position,
                                                                    Speed * Time.deltaTime);
                if (Vector3.Distance(Runners[N].transform.position, Runners[0].transform.position) <= PassDistance)
                {
                    N = 0;
                }
            }
            else
            {
                Runners[N].transform.position = Vector3.MoveTowards(Runners[N].transform.position,
                                                                    Runners[N + 1].transform.position,
                                                                    Speed * Time.deltaTime);
                if (Vector3.Distance(Runners[N].transform.position, Runners[N + 1].transform.position) <= PassDistance)
                {
                    N++;
                }
            }
        }
        if (forward == false)
        {
            if (N == 0)
            {
                Runners[N].transform.position = Vector3.MoveTowards(Runners[N].transform.position,
                                                                    Runners[Runners.Length -1].transform.position,
                                                                    Speed * Time.deltaTime);
                if (Vector3.Distance(Runners[N].transform.position, Runners[Runners.Length - 1].transform.position) <= PassDistance)
                {
                    N = Runners.Length - 1;
                }
            }
            else
            {
                Runners[N].transform.position = Vector3.MoveTowards(Runners[N].transform.position,
                                                                    Runners[N - 1].transform.position,
                                                                    Speed * Time.deltaTime);
                if (Vector3.Distance(Runners[N].transform.position, Runners[N - 1].transform.position) <= PassDistance)
                {
                    N--;
                }
            }
        }

    }
}
