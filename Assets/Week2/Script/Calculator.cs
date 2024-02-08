using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI label;

    public void PrintMessage(string msg)
    {
        label.text = msg;
    }

    public void Add(int number)
    {
        label.text = (number % 10).ToString();
    }
}
