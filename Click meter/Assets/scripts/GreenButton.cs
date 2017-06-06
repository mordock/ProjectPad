using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenButton : MonoBehaviour
{
    public Button clickButton;

    private void Start()
    {
        //If you do not press the green button, you can not press the red button.
        clickButton.interactable = false;
    }

    public void Update()
    {
        foreach (var touch in Input.touches)
        {
            //Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 3f && touch.position.y < Screen.height / 3f)
                //if (GetComponent<BoxCollider2D>().OverlapPoint(wp))
                //When the green button is pressed, the red button becomes active and can be clicked 
                {
                    clickButton.interactable = true;
                }
            }
            //When you release the green button, the red button automatically turns off again and you can not press the red button.
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (touch.position.x < Screen.width / 3f && touch.position.y < Screen.height / 3f)
                //if (GetComponent<BoxCollider2D>().OverlapPoint(wp))
                {
                    clickButton.interactable = false;
                }
            }
        }
        //These rules code below indicate my progress because we have tried four ways to make this code work.
        // This rules code below is the last failed attempt.

        /*if (Input.touchCount >= 1)
        {
        //This collider has been created that should cause the red button to become active when you press the green button.
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
        }*/
    }
}