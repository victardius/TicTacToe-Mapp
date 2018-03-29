using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject tutorialText;

    [SerializeField]
    public int levelToLoad;

    public void Start()
    {
        tutorialText.SetActive(false);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void tutorial()
    {
        
        tutorialText.SetActive(!tutorialText.activeSelf);
        
    }
}
