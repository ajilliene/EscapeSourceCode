using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour {

    public PlayerController player;

    public GameObject heartPrefab;
    public Transform container;

    private List<GameObject> spawnedHearts = new List<GameObject>();

    private void Update()
    {
        SetHealth(player.curHealth);
    }

    public void SetHealth(int health)
    {
        if (spawnedHearts.Count == health)
            return;

        while (spawnedHearts.Count < health)
        {
            spawnedHearts.Add(Instantiate(heartPrefab,container));
        }

        while (spawnedHearts.Count > health && health >= 0)
        {
            Destroy(spawnedHearts[0]);
            spawnedHearts.RemoveAt(0);
        }
    }
}
