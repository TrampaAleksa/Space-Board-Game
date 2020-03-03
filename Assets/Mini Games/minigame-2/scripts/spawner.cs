using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objects;

    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        Instantiate(objects[Random.Range(0,objects.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        StartCoroutine(StartSpawning());
    }

}
