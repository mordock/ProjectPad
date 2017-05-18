using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Vector2 targetPosition;
    private Quaternion rotation;
    public float speed = 1.0f;
    public float damping = 0.5f;

    private void Start () {
        //Remeber to add the tag to the object itself, Tag isnt the object name.
        this.targetPosition = GameObject.FindGameObjectWithTag("base").transform.position;
    }

    private void lookAt()
    {
        //var delta = targetPosition.position - transform.position;
        //delta.z = 0;
        rotation = Quaternion.LookRotation(targetPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    private void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition, speed * Time.deltaTime * damping);
    }
}
