using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public Transform target;

    void Start () {
        target = GameObject.FindGameObjectWithTag("base").transform;
        Vector3 dir = target.position - transform.position;

        //angle checks how far the attached object needs to rotate, the object did rotate but not far enough, thus the "- 90".
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
