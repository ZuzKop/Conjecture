using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera fpsCam;

    public AudioSource gunshot;
    public AudioSource gunhit;
    public AudioSource emptyGun;
    public AudioSource reloading;
    public AudioSource drumhit;
    public AudioSource gore;

    private bool gunGuard;

    private int ammo;
    private int maxAmmo = 3;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        gunGuard = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Shoot();
        }

        if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
            {
                if (hit.transform.name == "wallRight")
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

    private void Shoot()
    {
        if(!gunGuard)
        {
            if(ammo>0)
            {
                gunshot.Play();
                ammo--;

                RaycastHit hit;
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
                {
                    if (hit.transform.tag == "enemy")
                    {
                        Debug.Log("You hit zombie");
                        gunhit.Play();
                        drumhit.Play();
                        gore.Play();
                        Destroy(hit.transform.gameObject);
                        gameObject.GetComponent<PlayerManager>().AddKill();
                    }
                }
            }
            else
            {
                emptyGun.Play();
            }
        }



    }

    IEnumerator Reload()
    {
        gunGuard = true;
        reloading.Play();
        yield return new WaitForSeconds(1.9f);
        gunGuard = false;
        ammo = maxAmmo;
    }
}
