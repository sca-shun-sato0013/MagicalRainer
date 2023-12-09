using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScoreCounter : MonoBehaviour
{
    [HideInInspector] public enum TimeCountState { COUNT = 0, PAUSE, STOP, }
    public static TimeCountState timeCountState;

    public static float elapsedTime;
    public static int score;

    void Start()
    {
        timeCountState = TimeCountState.PAUSE;
        elapsedTime = 0;
        score = 0;
    }

    void Update()
    {
        switch (timeCountState)
        {
            case TimeCountState.COUNT:
                elapsedTime += Time.deltaTime;
                Debug.Log(elapsedTime);
                break;
            case TimeCountState.PAUSE:
                break;
            case TimeCountState.STOP:
                GlobalVariables.AliveTime = elapsedTime;
                GlobalVariables.Score = score;
                break;
        }
    }
}
