using Assets.classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CyclusButtonScript : MonoBehaviour {

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
