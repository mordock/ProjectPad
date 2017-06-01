using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {
	public GameObject fruit1, fruit2, fruit3, fruit4, fruit5;
	//cycle through the baselives and delete the appropriate fruit 
	void Update () {
		if(BaseBehaviour.baseLives == 4){
			Destroy(fruit1);
		}else
		if(BaseBehaviour.baseLives == 3){
			Destroy(fruit2);
		}else
		if(BaseBehaviour.baseLives == 2){
			Destroy(fruit3);
		}else
		if(BaseBehaviour.baseLives == 1){
			Destroy(fruit4);
		}else
		if(BaseBehaviour.baseLives == 0){
			Destroy(fruit5);
		}
	}
}