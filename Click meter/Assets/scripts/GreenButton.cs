using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenButton : MonoBehaviour {
    public Button clickButton; 
    
    public bool isClicked = false;

    public void GreenButtonClick()
    {
        
        isClicked = true;
        if (isClicked)
        {

            clickButton.interactable = true;
        }
    }
    
}
