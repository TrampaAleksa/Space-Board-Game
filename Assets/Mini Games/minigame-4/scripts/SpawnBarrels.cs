using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarrels : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objects;

    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        Instantiate(objects[Random.Range(0, objects.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        StartCoroutine(StartSpawning());
    }
}
