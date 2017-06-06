using Assets.classes;
using Assets.Classes;
using Assets.scripts.classes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RedButton : MonoBehaviour
{
    
    public Scrollbar Clickmeter;
    public float ClickTime = 1f;

    
    private float Click = 0f;
    private float lastClickTime = 0f;
    private float value = 0f;

    //Red button clickevent
    public void Knop(float value)
    {
        this.value = value;

        UpdateClick(value, false);
        
        //if statement for the bar. When the red button is pressed the bar gets full.
        if ((Click / 100f) >= 1)
        {
            //start cyclus when the app is opened for the first time.
            AppOpenDate appOpenDate = new AppOpenDate();
            appOpenDate.writeToJSON();

            LaatsteDatum laatstedatum = new LaatsteDatum();
            DateTime lastDate = laatstedatum.GetLastDate();
            
            //if the cyclus has reached the 7th day show "Cyclusmanager".
            //also show after every 7 days.
            if ((DateTime.Now - lastDate).Days >= 0)
            {
                SceneManager.LoadScene("CyclusManager");
            }
            else {
                RandomScene.loadRandomScene();
            }

        }
    }

    public void Update()
    {

        //if red button is not pressed, bar is slowly getting empty again.
        if (Click <= 0f || lastClickTime < ClickTime)
        {

            lastClickTime += Time.deltaTime;

            return;
        }

        UpdateClick(value, true);
    }

    private void UpdateClick(float delta, bool inverse)
    {
     
        //if statement for the deflate or for the load of the bar
        
        if (inverse)
        {
            
            Click -= value;
        }
        else
        {
            Click += value;
        }

        Click = Math.Max(0, Math.Min(Click, 100));
        
        Clickmeter.size = Click / 100f;
        lastClickTime = 0f;
    }
}