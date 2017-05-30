using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScreenManager : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void TerugKnop(){
		SceneManager.LoadScene ("Clickmeter");
	}

    public void BackCalendar()
    {
        SceneManager.LoadScene("Clickmeter");
    }
}
