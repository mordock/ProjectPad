using UnityEngine;

public class SprayBomb : MonoBehaviour
{
    public GameObject SprayBar;

    //Instantiate the cloud when the spray button is pressed
    public void OnClick()
    {
        GameObject sprayBar = Instantiate(SprayBar, transform.position, Quaternion.identity) as GameObject;
    }
}