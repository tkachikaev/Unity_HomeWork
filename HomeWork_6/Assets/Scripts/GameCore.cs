using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public Text pinTextL = null;
    public Text pinTextC = null;
    public Text pinTextR = null;

    public int pinL = 0;
    public int pinC = 0;
    public int pinR = 0;

    public void ClickButtonPinL()
    {
        pinL += 1;
        pinC -= 1;
        SetTextPins();

    }

    public void ClickButtonPinC()
    {
        pinC += 2;
        pinR -= 2;
        SetTextPins();
    }

    public void ClickButtonPinR()
    {
        pinC += 1;
        pinR += 2;
        SetTextPins();
    }

    private void CheckPinValid()
    {
        if (pinL <= 0) pinL = 0;
        if (pinL >= 10) pinL = 10;
        if (pinC <= 0) pinC = 0;
        if (pinC >= 10) pinC = 10;
        if (pinR <= 0) pinR = 0;
        if (pinR >= 10) pinR = 10;
    }

    public void SetTextPins()
    {
        CheckPinValid();
        pinTextL.text = pinL.ToString();
        pinTextC.text = pinC.ToString();
        pinTextR.text = pinR.ToString();
    }
}
