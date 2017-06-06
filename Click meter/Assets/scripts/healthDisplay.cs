using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
    private Text myText;
    //create text and fill it with the baseLives
    void Start()
    {
        myText = GetComponent<Text>();
    }

    public void Health()
    {
        myText.text = BaseBehaviour.baseLives.ToString();
    }
    void Update()
    {
        Health();
    }
}