using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject zombiePrefab;

    private float breaks;

    public bool game;

    public void Start()
    {
        game = true;
        breaks = 8f;

        SpawnZombie();
        SpawnZombie();
        SpawnZombie();

        StartCoroutine(Spawning());
        StartCoroutine(Faster());

    }


    public void SpawnZombie()
    {
        Instantiate(zombiePrefab, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length - 1)].transform);
    }

    IEnumerator Spawning()
    {
        while(game)
        {
            yield return new WaitForSeconds(breaks);
            SpawnZombie();
            SpawnZombie();
        }
    }

    IEnumerator Faster()
    {
        while(game && breaks >= 1.5f)
        {
            yield return new WaitForSeconds(4f);
            breaks -= 0.05f;
            
        }
    }


}
