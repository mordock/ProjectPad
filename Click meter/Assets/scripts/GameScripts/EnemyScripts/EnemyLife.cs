using UnityEngine;

public class EnemyLife : MonoBehaviour {

    public float lifePoints;

	void Start () {
        lifePoints = 1;   
        
        if (gameObject.tag == "SoldierAnt")
        {
            lifePoints = 2;
        }
    }
}
