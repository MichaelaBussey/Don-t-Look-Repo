using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource Heartbeat;
    public bool HeartbeatIsOff = true;
    void Start()
    {
        Heartbeat = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Anxiety_Meter anxiety_Meter = GameObject.FindWithTag("Player").GetComponent<Anxiety_Meter>();

        if (anxiety_Meter.anxietyCurrent >= 30 && HeartbeatIsOff == true)
        {
            Heartbeat.Play();
            HeartbeatIsOff = false;
        }
        else if (anxiety_Meter.anxietyCurrent < 30 && HeartbeatIsOff == false)
        {
            Heartbeat.Stop();
            HeartbeatIsOff = true;
        }
    }
}
