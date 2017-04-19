using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour {
    TextMesh character;    

	// Use this for initialization
	void Start () {
        character = gameObject.GetComponent<TextMesh>();        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        Debug.Log(character.text + " selected");

    }
}
