using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTimer : MonoBehaviour
{
    public float maxTime, minTime, timeModifier =1;
    private float timer;

    private void Start()
    {
        timer = Time.time;
        //TODO buscar en el manager el timeModifier
        maxTime *= timeModifier;
        if (maxTime < minTime)
            maxTime = minTime;
    }

    private void Update()
    {
        float currentTime = Time.time - timer;

        if (currentTime >= maxTime)
        {
            Debug.Log("Time!");
        }
        else if (maxTime - currentTime <= 1f)
        {
            Debug.Log("1");
        }
        else if (maxTime - currentTime <= 2f)
        {
            Debug.Log("2");
        }

        else if (maxTime - currentTime <= 3f)
        {
            Debug.Log("3");
        }
    }
}
