using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {
	public GameObject fruit1, fruit2, fruit3, fruit4, fruit5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
