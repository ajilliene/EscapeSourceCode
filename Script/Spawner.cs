using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;

    private float timeBtwSpwn;
    private float startTimeBtwSpwn;

    void Update()
    {
        if (timeBtwSpwn <= 0)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBtwSpwn = startTimeBtwSpwn;
        }
        else
        {
            timeBtwSpwn -= Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health.health -= -1; 
    }
}
