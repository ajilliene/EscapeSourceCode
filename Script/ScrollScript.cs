using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    // Background scroll speed can be set in Inspector with slider
    [Range(3f, 80f)]
    public float scrollSpeed = 3f;

    public bool goLeft; 

    // Start position of background movement
    Vector2 startPos;

    // Backgrounds new position
    float newPos;

    // Use this for initialization
    void Start()
    {
        // Getting backgrounds start position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        int mult = goLeft ? 1 : -1;

        // Calculating new backgrounds position repeating it depending on scrollOffset
        newPos += Time.deltaTime * -scrollSpeed * mult;

        // Setting new position
        transform.position = startPos + Vector2.right * newPos;
    }
}