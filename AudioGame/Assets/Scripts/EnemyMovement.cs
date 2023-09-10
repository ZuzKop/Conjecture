using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject target;

    private Vector3 position ;
    private Vector3 destination;
    float lerpDuration = 0.02f;

    private GameObject terror;

    // Start is called before the first frame update
    void Start()
    {
        terror = gameObject.transform.GetChild(0).gameObject;
        terror.SetActive(false);
        
        lerpDuration = Random.Range(0.018f, 0.028f);

        target = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(MoveToTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().Die();
        }
        if (other.tag == "terror")
        {
            terror.SetActive(true);
        }
    }


    IEnumerator MoveToTarget()
    {
        position = transform.position;
        destination = target.transform.position;

        float lerpTime = 0f;

        while(lerpTime<=1)
        {
            transform.position = Vector3.Lerp(position, destination, lerpTime);
            lerpTime += Time.deltaTime * lerpDuration;
            yield return null;
        }

        transform.position = destination;

    }
}
