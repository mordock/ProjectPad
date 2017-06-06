using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    public void HelpKnop()
    {
        SceneManager.LoadScene("help");
    }
}
