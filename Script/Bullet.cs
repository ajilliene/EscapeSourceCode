using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<PlayerController>().Damage(damageAmount);
            }

            Destroy(gameObject);
        }
        
    }
}
