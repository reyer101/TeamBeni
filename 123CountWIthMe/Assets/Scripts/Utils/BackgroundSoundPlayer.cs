using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundPlayer : MonoBehaviour {

    AudioSource effect;

	// Use this for initialization
	void Start () {
        effect = gameObject.GetComponent<AudioSource>();
		
	}
	
	void OnMouseDown()
    {
        effect.Play();
    }
}
