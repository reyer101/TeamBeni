using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScubaAnimator : MonoBehaviour {

    SpriteRenderer[] spriteRenderers = new SpriteRenderer[8];
    GameObject[] beniFrames;
    Quaternion beniRotation;
    Vector2 beniPosition;
    int animIndex = 1;
    int totalFrames = 0;

	// Use this for initialization
	void Start () {
        beniPosition = GameObject.FindGameObjectWithTag("Beni").transform.position;
        beniRotation = GameObject.FindGameObjectWithTag("Beni").transform.rotation;
        
        makeFrames();                   
	}

    void Update() {        
        
        if(totalFrames % 9 == 0)
        {
            switchFrame();
        }

        ++totalFrames;        
    }

    void switchFrame() {
        spriteRenderers[animIndex].enabled = false;

        if (animIndex == 7)
        {
            spriteRenderers[0].enabled = true;
            animIndex = -1;
        }
        else
        {
            spriteRenderers[animIndex + 1].enabled = true;
        }

        ++animIndex;
    }

    void makeFrames() {
        for(int i = 1; i < 9; ++i)
        {
            spriteRenderers[i-1] = ((GameObject) Instantiate(Resources
                .Load(Constants.scubaPath + i), beniPosition, beniRotation))
                .GetComponent<SpriteRenderer>();
                                         
        }    

    }
}
