using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCollision : MonoBehaviour {
	public int scoreValue = 10;
	private ScoreKeeper scoreKeeper;
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null) {
                    if (hit.collider.gameObject == gameObject)
                    {
                        scoreKeeper.Score(scoreValue);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
