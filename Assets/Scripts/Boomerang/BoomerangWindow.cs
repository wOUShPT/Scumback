using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class BoomerangWindow : MonoBehaviour
{
    private FMOD.Studio.EventInstance rummaging;
    private bool soundOn;
    void Start()
    {
        soundOn = false;
        rummaging = FMODUnity.RuntimeManager.CreateInstance("event:/Jogo do bumerangue/Rummaging");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (soundOn == false)
        {
            rummaging.start();
            soundOn = !soundOn;
        }
        else
        {
            rummaging.stop(STOP_MODE.IMMEDIATE);
            soundOn = !soundOn;
        }
        
    }
}
