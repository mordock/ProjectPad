using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Assets.Classes;
using UnityEngine.SceneManagement;

public class ButtonBehaviour1 : MonoBehaviour
{

    public Scrollbar Clickmeter;
    public float ClickTime = 1f;
    public Text text;

    private float Click = 0f;


    private float lastClickTime = 0f;
    private float value = 0f;

    public void Knop(float value)
    {
        this.value = value;

        UpdateClick(value, false);

        if ((Click / 100f) >= 1)
        {
            AppOpenDate appOpenDate = new AppOpenDate();
            appOpenDate.writeToJSON();
            //TODO Naar nieuwe scene gaan 
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Update()
    {
        if (Click <= 0f || lastClickTime < ClickTime)
        {
            lastClickTime += Time.deltaTime;

            return;
        }

        UpdateClick(value, true);
    }

    private void UpdateClick(float delta, bool inverse)
    {
        //BUGFIX: Inverse-boolean because Unity is lame
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