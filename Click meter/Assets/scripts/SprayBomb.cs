using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBomb : MonoBehaviour {
	public GameObject SprayBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick(){
		GameObject sprayBar = Instantiate(SprayBar, transform.position, Quaternion.identity) as GameObject;
	}
}
