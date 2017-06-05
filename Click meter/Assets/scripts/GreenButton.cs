using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenButton : MonoBehaviour
{
    public Button clickButton;
    
    private void Start()
    {
        //Wanneer je niet op de groene knop drukt, lukt het niet om op de rode knop te drukken.
        clickButton.interactable = false;
    }

    public void Update()
    {
        foreach (var touch in Input.touches)
        {
            //Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if(touch.position.x < Screen.width / 3f && touch.position.y < Screen.height / 3f)
                //if (GetComponent<BoxCollider2D>().OverlapPoint(wp))
                //Wanneer de groene button is ingedrukt, wordt de rode knop actief en kan je erop klikken.
                {
                    clickButton.interactable = true;
                }
            }
            //Wanneer je de groene knop loslaat dan wordt automatisch de rode knop weer inactief en kan je niet op de rode knop drukken.
            else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                if (touch.position.x < Screen.width / 3f && touch.position.y < Screen.height / 3f)
                //if (GetComponent<BoxCollider2D>().OverlapPoint(wp))
                {
                    clickButton.interactable = false;
                }
            }
        }
        //Deze regels code hieronder geven mijn voortgang aan, omdat we vier manieren hebben geprobeerd om deze code te laten werken.
        //Deze regels code hieronder is van de laatste mislukte poging.

        /*if (Input.touchCount >= 1)
        {
        //Hier is er een collider aangemaakt die ervoor zou moeten zorgen dat de rode knop actief wordt, wanneer je op de groene knop drukt.
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