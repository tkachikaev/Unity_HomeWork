using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSate : MonoBehaviour
{
    [SerializeField] private GameObject startTask = null;
    [SerializeField] private GameObject[] DisableTasks;
    private GameObject nowTask;

    private void Start()
    {
        startTask.SetActive(true);
        nowTask = startTask;

        for (int i = 0; i < DisableTasks.Length; i++)
        {
            DisableTasks[i].SetActive(false);
        }
    }

    public void GoNext(GameObject NextTask)
    {
       if (nowTask != null)
       {
            nowTask.SetActive(false);
            NextTask.SetActive(true);
            nowTask = NextTask;
       }
    }

    public void GoBack(GameObject BackTask)
    {
        if (nowTask != null)
        {
            nowTask.SetActive(false);
            BackTask.SetActive(true);
            nowTask = BackTask;
        }
    }

}
