using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public UIController UIController;
    public int Score;
    public int Gold;
    
    public void AddScore(int Score)
    {
        this.Score += Score;
        UIController.SetScoreText(this.Score);
    }

}
