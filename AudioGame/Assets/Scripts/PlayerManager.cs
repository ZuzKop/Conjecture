using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public AudioSource GameOver;
    public AudioSource ghastlyScreams;
    public AudioSource zombieAttack;
    public GameObject zombieManager;

    public GameObject sounds;
    public GameObject gameOverScreen;

    public Text score;
    private int kills;

    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        
    }

    public void AddKill()
    {
        kills++;
    }

    public void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sounds.SetActive(false);
        StartCoroutine(Noises());
        ghastlyScreams.Play();
        Debug.Log(kills);
        zombieManager.SetActive(false);
        score.text = "Your Score: " + kills;

    }


    IEnumerator Noises()
    {
        zombieAttack.Play();
        yield return new WaitForSeconds(0.2f);
        ghastlyScreams.Play();
        yield return new WaitForSeconds(0.2f);
        GameOver.Play();
        yield return new WaitForSeconds(1f);
        gameOverScreen.SetActive(true);

    }
}
