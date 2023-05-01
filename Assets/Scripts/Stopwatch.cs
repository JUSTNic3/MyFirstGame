using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public float timer;
    public int seconds;
    private TextMeshProUGUI TimerText;
    public int pointsCollected = Player.points;

    void Start()
    {
        timer = 0.0f;
        TimerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        pointsCollected = Player.points;
        if (pointsCollected < 6)
        {
            timer += Time.deltaTime;
            seconds = (int)(timer % 60);
            TimerText.text = seconds.ToString();
        }
    }
}
