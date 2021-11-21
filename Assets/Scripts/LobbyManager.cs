using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject controller1;
    public GameObject controller2;
    public int playerCount;
    public float counter;

    void Start()
    {
        controller1.SetActive(false);
        controller2.SetActive(false);
        playerCount = 0;
        counter = 5;
    }

    private void Update()
    {
        playerCount = PlayerInputManager.instance.playerCount;
        switch (PlayerInputManager.instance.playerCount)
        {
            case 0:
                controller1.SetActive(false);
                controller2.SetActive(false);
                break;
            case 1:
                controller1.SetActive(true);
                controller2.SetActive(false);
                break;
            case 2:
                controller1.SetActive(true);
                controller2.SetActive(true);
                break;
        }

        if (PlayerInputManager.instance.playerCount == 2)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                SceneManager.LoadScene("KinecticRage");
            }
        }
    }
}
