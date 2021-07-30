using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MISC : MonoBehaviour
{
    public AudioSource PlayerFootstep;
    void Start()
    {
        
    }

    public void Footstep()
    {
        PlayerFootstep.Play();
    }
}
