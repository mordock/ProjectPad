using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            BaseBehaviour.baseLives -= 1;
        }
        else if (collision.gameObject.tag == "SoldierAnt")
        {
            Destroy(collision.gameObject);
            BaseBehaviour.baseLives -= 1;
        }
    }
}
