using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnTrigger : MonoBehaviour
{
    public int levelIndex;
    public float delay;
    public GameObject spawnOnTrigger;

    private void OnTriggerEnter2D(Collider2D other)

    {
        Debug.Log("saojkhdaojdhsaoda");
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        if (spawnOnTrigger != null)
        {
            GameObject obj = Instantiate(spawnOnTrigger);
            obj.transform.position = transform.position;
        }

        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
    }
}
