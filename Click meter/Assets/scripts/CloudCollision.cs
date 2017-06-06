using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollision : MonoBehaviour {
	//wanneer de cloud een ant aanraakt word hij verwijderd zonder punten te krijgen.
	//door middel van layers wordt ervoor gezorgd dat alleen de ants worden verwijderd.
	private void OnCollisionEnter2D(Collision2D collision){
		Destroy(collision.gameObject);
		Debug.Log("coll");
	}


	void Update(){
		transform.Translate(0, -10 * Time.deltaTime, 0);
	}
}
