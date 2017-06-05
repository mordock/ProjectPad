using Assets.classes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CyclusButtonScript : MonoBehaviour {

    private const int CALCULATION_DURATION_DAYS = 7;
    
    public void Knop(bool antwoord)
    {
        if (antwoord)
        {
            Cyclus cyclusmanager = new Cyclus();
            cyclusmanager.ChangeCyclus();
        }
        
            SceneManager.LoadScene("MainMenu");
        
    }
}
