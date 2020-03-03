using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAIV2 : MonoBehaviour
{
    public static GameObject[] players = new GameObject[4];
    private GameObject enemy;

    float distance1;
    float distance2;
    float distance3;
    float distance4;
    float[] distances = new float[4];

    float minDistance;

    public NavMeshAgent agent; //enemy


     //OVAJ NIZ PROSLEDI TRAMPI

    void Awake()
    {
        players[0] = GameObject.FindGameObjectWithTag("Player 1");

        players[1] = GameObject.FindGameObjectWithTag("Player 2");

        players[2] = GameObject.FindGameObjectWithTag("Player 3");

        players[3] = GameObject.FindGameObjectWithTag("Player 4");

        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        calculateDistancesAndChase();
        if(distance1==99f && distance2==99f && distance3==99f && distance4 == 99f)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void calculateDistancesAndChase()
    {
        if (players[0] != null)
        {
            distance1 = Vector3.Distance(enemy.transform.position, players[0].transform.position);
        }
        else
        {
            distance1 = 99f;
            
        }
        if (players[1] != null)
        {
            distance2 = Vector3.Distance(enemy.transform.position, players[1].transform.position);
        }
        else
        {
            distance2 = 99f;
           
        }
        if (players[2] != null)
        {
            distance3 = Vector3.Distance(enemy.transform.position, players[2].transform.position);
        }
        else
        {
            distance3 = 99f;
            
        }
        if (players[3] != null)
        {
            distance4 = Vector3.Distance(enemy.transform.position, players[3].transform.position);
        }
        else
        {
            distance4 = 99f;
            
        }

        print(distance1);
        print(distance2);
        print(distance3);
        print(distance4);

        distances[0] = distance1;
        distances[1] = distance2;
        distances[2] = distance3;
        distances[3] = distance4;

        minDistance = findMinInArray(distances);

        if (players[0] != null && distance1 == minDistance)
        {
            //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, players[0].transform.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(players[0].transform.position);
        }
        if (players[1] != null && distance2 == minDistance)
        {
            // enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, players[1].transform.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(players[1].transform.position);
        }
        if (players[2] != null && distance3 == minDistance)
        {
            //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, players[2].transform.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(players[2].transform.position);
        }
        if (players[3] != null && distance4 == minDistance)
        {
            //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, players[3].transform.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(players[3].transform.position);
        }
    }

    public float findMinInArray(float[] array)
    {
        float min = 9999f;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;

    }
}
