using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
/*Metzli Castellanos
* Game Engine Scripting Course
* Credit: Professor Cameron Cintron, Microsoft C# Documentation site, C# 10 in a Nutchell and tutorials
* 
*/
public class Calculator : MonoBehaviour
{
    // TextMeshProUGUI variable assigned to inspector
    public TextMeshProUGUI label;

    //Temporary Float stores previous input value for when still working on the calculation
    public float prevInput;

    //Bool clearPrevInput will help in clearing previous input if it is True/False if typing another value input.
    public bool clearPrevInput;

    private EquationType equationType;

    private void Start()
    {
        Clear();
    }

    //public void PrintMessage(string msg)
    //{
    //    label.text = msg;
    //}

    public void AddInput(string input)
    {
        clearPrevInput = true;

        if (clearPrevInput)
        {
            label.text = string.Empty;

            clearPrevInput = false;
        }
        
        //new input will be added to the previous Input that was cleared
        label.text = label.text + input;
    }

    //Fuction code for Add, Subtract, Multiply, Divide. Which can input the register equation.

    public void SetEquationAsAdd()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }

    public void SetEquationAsSubtract()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.SUBTRACT;
    }

    public void SetEquationAsMultiply()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.MULTIPLY;
    }

    public void SetEquationAsDivide()
    {
        prevInput = float.Parse(label.text);
        clearPrevInput = true;
        equationType = EquationType.DIVIDE;
    }

    // Fuctions that calculate the inputs and display that sum
    public void Add()
    {
        float inputSum;

        inputSum = prevInput + (float.Parse(label.text));

        label.text = inputSum.ToString();

    }

    public void Subtract()
    {
        float inputSum;

        inputSum = prevInput - (float.Parse(label.text));

        label.text = inputSum.ToString();
    }

    public void Multiply()
    {
        float inputSum;

        inputSum = prevInput * (float.Parse(label.text));

        label.text = inputSum.ToString();
    }

    public void Divide()
    {
        float inputSum;

        inputSum = prevInput / (float.Parse(label.text));

        label.text = inputSum.ToString();
    }


    public void Clear()
    {
        //Reset the display text to 0
        label.text = "0";
        //bool set as clear to reset display
        clearPrevInput = true;
        //float reset to 0
        prevInput = 0;

        //TODO: Leave this alone
        equationType = EquationType.None;
    }

    public void Calculate()
    {
        //equationType is Add/Subtract/Multiply/Divide and call the correct function
        if (equationType == EquationType.ADD)
        {
            Add();
        }
        else if (equationType == EquationType.SUBTRACT)
        {
            Subtract();
        }
        else if (equationType == EquationType.MULTIPLY)
        {
            Multiply();
        }
        else if (equationType == EquationType.DIVIDE)
        {
            Divide();
        }
        //If none of the above happens then the message "Error" appears
        else
        {
            label.text = "Error";
        }
     
    }

    //TODO: Leave this alone
    public enum EquationType
    {
        None = 0,
        ADD = 1,
        SUBTRACT = 2,
        MULTIPLY = 3,
        DIVIDE = 4
    }

}
