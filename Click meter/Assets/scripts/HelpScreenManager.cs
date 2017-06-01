using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScreenManager : MonoBehaviour
{

	public void TerugKnop(){
		SceneManager.LoadScene ("Clickmeter");
	}

    public void BackCalendar()
    {
        SceneManager.LoadScene("Clickmeter");
    }
}
