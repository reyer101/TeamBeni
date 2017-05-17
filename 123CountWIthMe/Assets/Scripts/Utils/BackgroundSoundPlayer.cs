using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundPlayer : MonoBehaviour {

    AudioSource effect;
    SpriteRenderer[] spriteRenderers = new SpriteRenderer[8];
    GameObject[] bubbleFrames;
    Quaternion bubbleRotation;
    Vector2 bubblePosition;
    public int imageFrames;
    int totalFrames, animIndex;
    bool bubblesAcive;
    public bool isLettersLevel;

    // Use this for initialization
    void Start () {
        animIndex = 1;
        bubblesAcive = false;
        bubbleRotation = GameObject.FindGameObjectWithTag("GuessChar").transform.rotation;        
        effect = gameObject.GetComponent<AudioSource>();       
		
	}

    void Update() {
        if(isLettersLevel)
        {
            if (totalFrames % imageFrames == 0 && bubblesAcive)
            {
                switchFrame();
            }

            ++totalFrames;
        }        
    }
	
	void OnMouseDown()
    {
        effect.Play();    //Plays bubble sound effect

        if (isLettersLevel)
        {
            removeBubbles();
            StopCoroutine("bubbleWait");
            bubblesAcive = true;            
            bubblePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //Gets position of the mouse cursor
            bubblePosition.y += 1.4f;    //Bubble spawn position offset         

            for (int i = 1; i < 9; ++i)
            {
                spriteRenderers[i - 1] = ((GameObject)Instantiate(Resources.Load(
                    Constants.bubblePath + i), bubblePosition, bubbleRotation)).
                    GetComponent<SpriteRenderer>();
            }

            StartCoroutine("bubbleWait");
        }                
                    
    }

    IEnumerator bubbleWait()
    {
        yield return new WaitForSeconds(4.25f);
        bubblesAcive = false;
        removeBubbles();
    }

    void switchFrame()
    {
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

    void removeBubbles()
    {
        animIndex = 1;
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubbles");

        foreach(GameObject bubble in bubbles)
        {
            Destroy(bubble);
        }
    }

}
