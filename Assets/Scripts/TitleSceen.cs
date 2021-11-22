using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceen : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        //FMODUnity.RuntimeManager.CreateInstance("snapshot:/Menu").start();
        SceneManager.LoadScene("Lobby");
    }
}
