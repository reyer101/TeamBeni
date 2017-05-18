using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    private static MenuPlayer instance = null;
    string currentScene, lastScene;
    AudioSource source;
    public static MenuPlayer Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        lastScene = "Menu";
        source = gameObject.GetComponent<AudioSource>();
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
            return;
        } 
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject); 
              
    }    

    void Update()
    {        
        currentScene = SceneManager.GetActiveScene().name;

        if (!currentScene.Contains("Menu") && !currentScene.Contains("Screen") )
        {
            source.Stop();
            lastScene = " ";      
            Debug.Log("Here");      
        }
        else
        {
            if(!lastScene.Contains("Menu") && !lastScene.Contains("Screen"))
            {
                source.Play();
                lastScene = "Menu";
            }                
        }

    }
}
