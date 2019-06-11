using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    private int curHealth;
    public int maxHealth;

    private float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    public AudioClip shootSound;
    public AudioClip activateSound;
    public AudioClip sleepSound;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

  void Start()
    {
        curHealth = maxHealth;
    }
 void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);

        RangeCheck();

        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }

    }

    void RangeCheck()
    {

        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange && !awake)
        {
            awake = true;

            if (activateSound != null)
                AudioSource.PlayClipAtPoint(activateSound, transform.position);
        }

        if(distance > wakeRange && awake)
        {
            awake = false;

            if (sleepSound != null)
                AudioSource.PlayClipAtPoint(sleepSound, transform.position);
        }
    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;
        
        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if (shootSound != null)
                AudioSource.PlayClipAtPoint(shootSound, transform.position);

            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;


            }

            if(attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0; 
            }

        }
    }
}
