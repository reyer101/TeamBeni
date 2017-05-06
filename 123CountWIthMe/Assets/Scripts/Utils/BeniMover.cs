using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeniMover : MonoBehaviour {

    public float moveSpeed;
    float initialPosition;
    bool dirUp = true;

	// Use this for initialization
	void Start () {
        initialPosition = transform.position.y;
        Debug.Log("Initial position: " + initialPosition);        

    }
	
	// Update is called once per frame
	void Update () {
        if (dirUp)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * moveSpeed));
        }
        else
        {
            transform.Translate(Vector3.down * (Time.deltaTime * moveSpeed));            
        }

        if (transform.position.y > initialPosition + .5)
        {            
            dirUp = false;
        }
        else if (transform.position.y < initialPosition - .5)
        {
            dirUp = true;
        }
    }
}
