using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ship takes damage
            other.GetComponent<Ship>().health -= damage;
            Debug.Log(other.GetComponent<Ship>().health);
            Destroy(gameObject);
            Health.health -= 1;
        }
    }
}
