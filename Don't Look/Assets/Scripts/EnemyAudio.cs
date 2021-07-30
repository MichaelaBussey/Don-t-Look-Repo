using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    AudioSource enemyFootsteps;
    void Start()
    {
        enemyFootsteps = GetComponent<AudioSource>();
    }

    public void PlayEnemyFootsteps()
    {
        enemyFootsteps.Play();
    }
}
