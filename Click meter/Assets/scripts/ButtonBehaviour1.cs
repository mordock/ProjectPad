using Assets.classes;
using Assets.Classes;
using Assets.scripts.classes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonBehaviour1 : MonoBehaviour
{

    public Scrollbar Clickmeter;
    public float ClickTime = 1f;


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

            LaatsteDatum laatstedatum = new LaatsteDatum();
            DateTime lastDate = laatstedatum.GetLastDate();
            //check if it's time to ask the question if user smoked or not.
            Debug.Log((DateTime.Now - lastDate).TotalDays);
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