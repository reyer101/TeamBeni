using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    string tag;
    AudioSource clickSound;
    SpriteRenderer rend;
    Color tint;

    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        tint = new Color();
        ColorUtility.TryParseHtmlString("#D5D5D5FF", out tint);
        tag = gameObject.tag;
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

        switch (tag)
        {
            case "Color":
                SceneManager.LoadScene("ColorMenu");
                break;
            case "Letter":
                SceneManager.LoadScene("LetterMenu");
                break;
            case "Number":
                SceneManager.LoadScene("NumberMenu");
                break;
            case "Beni":
                SceneManager.LoadScene("MainMenu");
                break;
        }        

    }
}
