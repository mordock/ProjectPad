using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Vector2 targetPosition;
    private Quaternion rotation;
    public float speed = 1.0f;
    public float damping = 0.5f;

    private void Start () {
        this.targetPosition = GameObject.FindGameObjectWithTag("base").transform.position;
    }

    private void Update () {
        //To get fluid movement on units speed is multiplied by deltatime, other time functions exist but are too fast.
        this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition, speed * Time.deltaTime * damping);
    }
}
