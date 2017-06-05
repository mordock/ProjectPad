using Assets.classes;
using Assets.scripts.classes;
using System;
using UnityEngine;

public class CyclusButtonScript : MonoBehaviour
{

    private const int DAYS_BETWEEN_QUESTION = 7;

    //if statement to show the questionscene once a week
    public void Knop(bool antwoord)
    {
        if (antwoord)
        {
            Cyclus cyclusmanager = new Cyclus();
            cyclusmanager.ChangeCyclus();
        }

        LaatsteDatum laatstedatum = new LaatsteDatum();
        laatstedatum.WriteFirstDate(DateTime.Now);
        RandomScene.loadRandomScene();
    }
}
