using UnityEngine;
using System;
using TMPro;
public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private bool racing = false;
    private TimeSpan bestTime;

    public delegate void TimeEvent();
    
    [SerializeField] int penaltyTimeVal = 3;
    [SerializeField] private TMP_Text raceTimeText, bestTimeText;
    [SerializeField] private string bestTimeKey = "LVLBestTime";

    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceFinish;
        SlalonFlag.RacePenalty += AddRacePenalty;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(bestTimeKey))
        {
            int bestTimeTicks = PlayerPrefs.GetInt(bestTimeKey);
            bestTime = new TimeSpan(bestTimeTicks);
            bestTimeText.text = "Best Time: " + bestTime.ToString("ss\\:ff");
        }
        else
        {
            bestTime = new TimeSpan(int.MaxValue);
            bestTimeText.text = "Best Time: 00:00";
        }
        PlayerPrefs.DeleteKey(bestTimeKey);

        Debug.Log("best time: " + bestTime.ToString());
    }

    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0,0,penaltyTimeVal);
    }
    void OnRaceStart()
    {
        racing = true;
        raceStart = DateTime.Now;
        
    }

    void OnRaceFinish()
    {
        racing = false;
        if (raceTime < bestTime)
        {
            bestTime = raceTime;
            bestTimeText.text = "Best Time: ;" + bestTime.ToString("ss\\:ff");
            PlayerPrefs.SetInt(bestTimeKey,(int) bestTime.Ticks);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if (racing)
        {
            raceTime = DateTime.Now - raceStart + penaltyTime;
            Debug.Log("Race time " + raceTime);
            raceTimeText.text = "Time: " + raceTime.ToString("ss\\:ff");
        }
    }
}
