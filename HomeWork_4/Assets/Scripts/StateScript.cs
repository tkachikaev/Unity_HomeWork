using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
    [SerializeField] private GameObject FirstScreen;
    [SerializeField] private GameObject DisabledScreen;
    private GameObject curentScreen;

    private void Start()
    {
        FirstScreen.SetActive(true);
        curentScreen = FirstScreen;
        if (DisabledScreen != null)
        {
            DisabledScreen.SetActive(false);
        };
    }

    public void ChangeState(GameObject state)
    {
        if (curentScreen != null)
        {
            curentScreen.SetActive(false);
            state.SetActive(true);
            curentScreen = state;
        }
    }
}
