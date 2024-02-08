using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
/*Metzli Castellanos
* Game Engine Scripting Course
* Credit: Professor Cameron Cintron, Microsoft C# Documentation site 
* 
*/
public class Calculator : MonoBehaviour
{
    // TextMeshProUGUI variable assigned to inspector
    public TextMeshProUGUI label;

    //Float stores previous input value for when still working on the calculation
    public float prevInput;

    //Bool clearPrevInput will help in clearing previous input if it is True/False if typing another value input.
    public bool clearPrevInput;

   
    private EquationType equationType;

    private void Start()
    {
        Clear();
    }

    
    public void AddInput(string input)
    {
        clearPrevInput = true;

        if (clearPrevInput)
        {
            //Note to self for future reference: not text.label since text is a property while label is an instance 
            label.text = string.Empty;

            clearPrevInput = false;
        }
        //new input will be added to the previous Input that was cleared
        label.text = label.text + input;
    }

    public void SetEquationAsAdd()
    {
        //TODO: Store the current input value on the text label into the float variable you created.
        //      Hint. You will need to google float.Parse() and pass in the string value of the label.
        //TODO: Set the bool you made to true so that the next number that gets typed in clears the calculator display.
        prevInput = float.Parse(text.text);
        clearPrevInput = true;
        equationType = EquationType.ADD;
    }



}
