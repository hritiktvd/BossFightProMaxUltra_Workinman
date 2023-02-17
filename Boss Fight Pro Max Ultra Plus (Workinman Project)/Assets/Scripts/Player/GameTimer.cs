using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float currentTime;
    public static float finalTime;

    private void Start()
    {
        EventsManager.onGameOver += getCompletionTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
    }

    private void getCompletionTime()
    {
        if (EventsManager.isBossDead)
        {
            finalTime = currentTime;
            Debug.Log("Final Time is: " + finalTime.ToString("0.000"));
            EventsManager.onGameOver -= getCompletionTime;
        }
    }

}
