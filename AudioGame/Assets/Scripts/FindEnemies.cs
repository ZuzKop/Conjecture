using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemies : MonoBehaviour
{
    public Camera fpsCam;

    public AudioSource moan;
    private float hearable;
    private float turn;
    private float vol = 0f;
    private float duration = 0.5f;

    public AudioSource thud;
    private bool WallGuard;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        hearable = 0f;
        turn = 0f;

        WallGuard = false;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (hit.transform.tag == "enemy")
            {
                hearable = 1;
                vol = (10 / hit.distance);
            }
            else
            {
                hearable = 0;
            }

            if(hit.transform.tag == "wall")
            {
                StartCoroutine(WallHit());
            }
        }
        else
        {
            hearable = 0;
        }

        if (hearable == 0)
        {
            if (turn > 0)
                turn -= 0.06f;
            else turn = 0;
        }
        else if (hearable == 1)
        {
            if (turn < 1)
                turn += 0.06f;
            else turn = 1;
        }

        vol *= turn;
        //Debug.Log(vol + " " + turn);
        moan.volume = vol;

    }

    IEnumerator WallHit()
    {
        if(!WallGuard)
        {
            WallGuard = true;
            thud.Play();
            yield return new WaitForSeconds(1.3f);
            WallGuard = false;
        }
    }


}

