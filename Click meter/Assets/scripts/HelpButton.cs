﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour 
{

    
	public void HelpKnop(){
		SceneManager.LoadScene ("help");
	}

    public void CalendarKnop()
    {
        SceneManager.LoadScene("Calendar");
    }
}
