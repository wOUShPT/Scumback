using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject player1Background;
    public GameObject player2Background;
    public GameObject player1Prompt;
    public GameObject player2Prompt;
    public GameObject playerControllersGameObject;
    public GameObject controller1;
    public GameObject controller2;
    public GameObject player1Text;
    public GameObject player2Text;
    public GameObject controller1Text;
    public GameObject controller2Text;
    public TextMeshProUGUI readyText;
    public int playerCount;
    public float counter;
    private GamesManager _gamesManager;
    
    private bool onMenu;

    private EventInstance _music;
    
    private void Awake()
    {
        _music = FMODUnity.RuntimeManager.CreateInstance("event:/Música/Main menu");
        _music.start();
    }

    private void OnDisable()
    {
        _music.stop(STOP_MODE.IMMEDIATE);
    }

    IEnumerator Start()
    {
        onMenu = false;
        titleScreen.SetActive(true);
        player1Background.SetActive(false);
        player2Background.SetActive(false);
        player1Prompt.SetActive(false);
        player2Prompt.SetActive(false);
        controller1.SetActive(false);
        controller2.SetActive(false);
        playerCount = 0;
        counter = 5;
        yield return new WaitForSeconds(5f);
        titleScreen.SetActive(false);
        player1Background.SetActive(true);
        player2Background.SetActive(true);
        player1Prompt.SetActive(true);
        player2Prompt.SetActive(true);
        playerControllersGameObject.SetActive(true);
        onMenu = true;
        _gamesManager = FindObjectOfType<GamesManager>();
    }

    private void Update()
    {
        if (onMenu)
        {
            playerCount = PlayerInputManager.instance.playerCount;
            switch (PlayerInputManager.instance.playerCount)
            {
                case 0:
                    controller1.SetActive(false);
                    controller2.SetActive(false);
                    player1Text.SetActive(false);
                    player2Text.SetActive(false);
                    controller1Text.SetActive(true);
                    controller2Text.SetActive(true);
                    break;
                case 1:
                    controller1.SetActive(true);
                    controller2.SetActive(false);
                    player1Text.SetActive(true);
                    player2Text.SetActive(false);
                    controller1Text.SetActive(false);
                    controller2Text.SetActive(true);
                    break;
                case 2:
                    controller1.SetActive(true);
                    controller2.SetActive(true);
                    player1Text.SetActive(true);
                    player2Text.SetActive(true);
                    controller1Text.SetActive(false);
                    controller2Text.SetActive(false);
                    break;
            }

            if (PlayerInputManager.instance.playerCount == 2)
            {
                readyText.gameObject.SetActive(true);
                counter -= Time.deltaTime;
                counter = Mathf.Clamp(counter, 0, 5);
                readyText.text = "Game starting in " + Mathf.Round(counter);
                if (counter <= 0)
                {
                    foreach (var snapshot in _gamesManager.snapshots)
                    {
                        snapshot.stop(STOP_MODE.IMMEDIATE);
                    }

                    _gamesManager.snapshots[_gamesManager.currentLevel].start();
                    SceneManager.LoadScene(_gamesManager.levels[_gamesManager.currentLevel]);
                }
            }
        }
    }
}
