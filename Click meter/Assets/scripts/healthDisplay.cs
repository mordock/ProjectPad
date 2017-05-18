using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour {
	private Text myText;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
	}

	public void Health(){
		myText.text = BaseBehaviour.baseLives.ToString();
	}	
	
	// Update is called once per frame
	void Update () {
		Health();
	}
}
