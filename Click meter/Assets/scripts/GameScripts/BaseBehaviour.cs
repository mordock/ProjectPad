﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBehaviour : MonoBehaviour
{
    public static int baseLives = 5;

    void Update()
    {
        if (baseLives <= 0)
        {
            SceneManager.LoadScene("GameOver");
            baseLives = 5;
        }   
   }

    void OnGUI()
    {
        GUI.Label(new Rect(-10, -10, 20, 20), baseLives.ToString());
    }
}