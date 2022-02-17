using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceen : MonoBehaviour
{
    private EventInstance _music;

    private void Awake()
    {
        
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        //FMODUnity.RuntimeManager.CreateInstance("snapshot:/Menu").start();
        SceneManager.LoadScene("Lobby");
    }
}
