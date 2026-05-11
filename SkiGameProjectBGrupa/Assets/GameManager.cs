using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private bool racing = false;

    public delegate void TimeEvent();
    
    [SerializeField] int penaltyTimeVal = 3;

    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceFinish;
        SlalonFlag.RacePenalty += AddRacePenalty;
    }

    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0,0,penaltyTimeVal);
    }
    void OnRaceStart()
    {
        racing = true;
        raceStart = DateTime.Now;
        Debug.Log("Race Start");
    }

    void OnRaceFinish()
    {
        racing = false;
        Debug.Log("Race Finish");
    }

    private void Update()
    {
        if (racing)
        {
            raceTime = DateTime.Now - raceStart + penaltyTime;
            Debug.Log("Race time " + raceTime);
        }
    }
}
