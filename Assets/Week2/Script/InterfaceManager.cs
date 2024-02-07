using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI label;


    // Send message on cosole
   public void PrintMessage()
   {
        label.text = "Hello";
        
   }
     
}
