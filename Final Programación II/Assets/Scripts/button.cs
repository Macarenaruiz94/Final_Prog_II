using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public string scene;
    public GameObject hideText;
    public GameObject showText;

    private void Start()
    {
        hideText.SetActive(true);
        showText.SetActive(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadCredits()
    {
        hideText.SetActive(false);
        showText.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
