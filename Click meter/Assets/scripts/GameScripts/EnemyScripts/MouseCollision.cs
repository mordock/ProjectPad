using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseCollision : MonoBehaviour {
	public int scoreValue = 10;
    public int lifeRemoved = -1;
	private ScoreKeeper scoreKeeper;
    private EnemyLife enemyLife;
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        enemyLife = GetComponent<EnemyLife>();
	}

	private void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null) {
                    if (hit.collider.gameObject == gameObject)
                    {
                        enemyLife.lifePoints--;

                        if (enemyLife.lifePoints <= 0)
                        {
                            //destruction of enemies and score adding is handled here because different enemeis have different amounts of health,
                            //handling unit destruction and point adding seperately leads to unnecessary complications.
                            scoreKeeper.Score(scoreValue);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
