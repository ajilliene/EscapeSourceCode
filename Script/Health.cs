using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject Heart_Full, Heart_2, Heart_3, Heart_4;
    public static int health;

    private void Start()
    {
        health = 4;
        Heart_Full.gameObject.SetActive(true);
        Heart_2.gameObject.SetActive(true);
        Heart_3.gameObject.SetActive(true);
        Heart_4.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (health > 4)
            health = 4;

        switch (health)
        {
            case 4:
                Heart_Full.gameObject.SetActive(true);
                Heart_2.gameObject.SetActive(true);
                Heart_3.gameObject.SetActive(true);
                Heart_4.gameObject.SetActive(true);
                break;
            case 3:
                Heart_Full.gameObject.SetActive(true);
                Heart_2.gameObject.SetActive(true);
                Heart_3.gameObject.SetActive(true);
                Heart_4.gameObject.SetActive(false);
                break;
            case 2:
                Heart_Full.gameObject.SetActive(true);
                Heart_2.gameObject.SetActive(true);
                Heart_3.gameObject.SetActive(false);
                Heart_4.gameObject.SetActive(false);
                break;
            case 1:
                Heart_Full.gameObject.SetActive(true);
                Heart_2.gameObject.SetActive(false);
                Heart_3.gameObject.SetActive(false);
                Heart_4.gameObject.SetActive(false);
                break;
            case 0:
                Heart_Full.gameObject.SetActive(false);
                Heart_2.gameObject.SetActive(false);
                Heart_3.gameObject.SetActive(false);
                Heart_4.gameObject.SetActive(false);
                break;
        }
    }

}
