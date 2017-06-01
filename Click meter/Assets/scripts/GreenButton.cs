using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenButton : MonoBehaviour
{
    public Button clickButton;

    private void Start()
    {
        clickButton.interactable = false;
    }

    public void Update()
    {
        if (Input.touchCount >= 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (GetComponent<BoxCollider2D>().OverlapPoint(wp))
            {
                clickButton.interactable = true;
            }
            else
            {
                clickButton.interactable = false;
            }
        }
        else
        {
            clickButton.interactable = false;
        }
    }
}