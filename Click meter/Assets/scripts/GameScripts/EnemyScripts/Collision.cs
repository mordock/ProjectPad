using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            BaseBehaviour.baseLives -= 1;
            Destroy(collision.gameObject);
        }
    }
}
