using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Introduction;
    public GameObject Credits;
    public GameObject mainMenu;

    public AudioSource Creds;
    public AudioSource Intro;

    public void CreditsButton()
    {
        Credits.SetActive(true);
        mainMenu.SetActive(false);

    }
    public void IntroductionButton()
    {
        Introduction.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void IntroductionReplay()
    {
        Intro.Play();
    }

    public void CreditsReplay()
    {
        Creds.Play();
    }

    public void BackButton()
    {
        Credits.SetActive(false);
        Introduction.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
