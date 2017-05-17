using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReplayButton : MonoBehaviour {

    SpriteRenderer rend;
    AudioSource clickSound;
    Color tint;

	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        tint = new Color();
        ColorUtility.TryParseHtmlString("#D5D5D5FF", out tint);
        clickSound = gameObject.GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        rend.color = tint;
    }

    void OnMouseExit()
    {
        rend.color = Color.white;
    }

    IEnumerator OnMouseDown()
    {
        clickSound.Play();
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadSceneAsync(GameUtils.lastLevel);       

    }
}
