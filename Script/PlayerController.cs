using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int maxHealth = 100;

    public int deathSceneIndex = 6;

    private Rigidbody2D rb;

    private float jumpTimeCounter;
    private float jumpTime;
    private bool isJumping;

    private float moveInput;
    private bool isGrounded;

    [System.NonSerialized]
    public int curHealth;

    public AudioClip damageSound;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);


        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

    }

    public void Damage(int amount)
    {
        if (damageSound != null)
            AudioSource.PlayClipAtPoint(damageSound, transform.position);

        curHealth -= amount;

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        SceneManager.LoadScene(deathSceneIndex);
    }
}