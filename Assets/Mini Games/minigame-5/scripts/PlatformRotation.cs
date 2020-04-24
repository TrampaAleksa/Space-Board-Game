using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public Transform startPos;
    private Vector3 firstPos;
    private Vector3 nextPos;
    public float moveSpeed;


    private Vector3 RotatePos1;
    private Vector3 RotatePos2;
    private Vector3 startRotation;


    bool rightPos = false;
    bool leftPos = false;


    //TO DO- onemopguciti da se jedna te ista fja pozove u randomu 2 i vise puta za redom 

    public IEnumerator function1;
    public IEnumerator function2;
    public IEnumerator function3;

    IEnumerator[] nizFja = new IEnumerator[3];

    void Awake()
    {
        putIESINarray();
        initializeRandomFunction();
    }


    void Start()
    {
        nextPos = startPos.position;

        startRotation.x = this.transform.eulerAngles.x;
        startRotation.y = this.transform.eulerAngles.y;
        startRotation.z = this.transform.eulerAngles.z;

        RotatePos1.x = this.transform.eulerAngles.x;
        RotatePos1.y = this.transform.eulerAngles.y;
        RotatePos1.z = this.transform.eulerAngles.z + 351;

        RotatePos2.x = this.transform.eulerAngles.x;
        RotatePos2.y = this.transform.eulerAngles.y;
        RotatePos2.z = this.transform.eulerAngles.z + 11;

        StartCoroutine(startRandomFunction1());
    }

    private void Update()
    {
        print(function1);
        print("time: " + Time.realtimeSinceStartup);
    }

    public IEnumerator rotateY()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            this.transform.Rotate(0f, 0.1f, 0f, Space.World);
            print("vrti");
        }
    }

    public IEnumerator moveLeftRight()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            if (transform.position == posA.position)
            {
                nextPos = posB.position;
            }

            if (transform.position == posB.position)
            {
                nextPos = posA.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
        }
    }

    public IEnumerator rotateLeftRight()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);

            if (rightPos == false && leftPos == false)
            {
                this.transform.Rotate(0, 0, -0.2f, Space.World);
            }

            if (this.transform.eulerAngles == RotatePos1)
            {
                rightPos = true;
                leftPos = false;
            }

            if (rightPos == true && leftPos == false)
            {
                this.transform.Rotate(0, 0, 0.2f, Space.World);
            }

            if (this.transform.eulerAngles == RotatePos2)
            {
                leftPos = true;
                rightPos = false;
            }

            if (rightPos == false && leftPos == true)
            {
                this.transform.Rotate(0, 0, -0.2f, Space.World);
            }
        }
    }

    public void putIESINarray()
    {
        nizFja[0] = rotateY();
        nizFja[1] = rotateLeftRight();
        nizFja[2] = moveLeftRight();
    }

    public void initializeRandomFunction()
    {
        function1 = nizFja[0];
        function2 = nizFja[1];
        function3 = nizFja[2];
    }

    public IEnumerator startRandomFunction1()
    {
        //function= nizFja[Random.Range(0, nizFja.Length - 1)];
        while (true)
        {
            yield return new WaitForSeconds(10f);
            StartCoroutine(
                function3); //stavljanje random fje u function promenljivu u radi u zasebnoj fji ( koju pozivas u updatu na svakih 10 ?) 


            yield return new WaitForSeconds(10f);
            StopCoroutine(function3);

            yield return new WaitForSeconds(10f);
            StartCoroutine(function2);


            yield return new WaitForSeconds(10f);
            StopCoroutine(function2);

            yield return new WaitForSeconds(10f);
            StartCoroutine(function1);


            yield return new WaitForSeconds(10f);
            StopCoroutine(function1);
        }
    }
}