using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBomb : MonoBehaviour {
	public GameObject SprayBar;
	public int numberOfBombs = 3;

	//Instantiate the cloud when the spray button is pressed
	public void OnClick(){
	if(numberOfBombs > 0){
		Instantiate(SprayBar, transform.position, Quaternion.identity);
		numberOfBombs -= 1;
		}
	}
}