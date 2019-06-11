using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private Vector2 targetPos;

    public int health = 4;

    public int deathSceneIndex = 6;

    Rigidbody2D rb;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 15)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + 15);
          
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -15)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - 15);
          
        }
    }

    private void FixedUpdate()
    {
        if (health == 0)
        {
            Die();
        }
    }
    private void Die()
    {
        SceneManager.LoadScene(deathSceneIndex);
    }

}
