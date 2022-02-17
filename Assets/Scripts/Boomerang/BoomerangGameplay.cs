using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoomerangGameplay : MonoBehaviour
{
    //Throw Info
    public float ThrowAngle = 90f;
    public float ThrowRotationSpeed = 50f;

    //Game Object References
    //public List<GameObject> Player;
    public List<BoomerangPlayer> PlayerScript;

    //Timers
    public float StarTime = 2f;
    public float GameTime = 5f;
    private float Timer;

    public int resetCounter;

    private GamesManager _gamesManager;

    private EventInstance _music;

    enum State
    {
        START,
        AIM,
        RETURN,
        END
    }

    private State GameState;

    private void Awake()
    {
        _gamesManager = FindObjectOfType<GamesManager>();
        _gamesManager.StopAllSnapShots();
        Debug.Log(_gamesManager.levels[_gamesManager.currentLevel]);
        _gamesManager.snapshots[_gamesManager.currentLevel].start();
        _music = FMODUnity.RuntimeManager.CreateInstance("event:/Música/Bumerangue song");
        _music.start();
    }

    void Start()
    {
        resetCounter = 0;
        _gamesManager = FindObjectOfType<GamesManager>();
        //PlayerScript = Player.GetComponent<BoomerangPlayer>();

        foreach(BoomerangPlayer ps in PlayerScript)
        {
            ps.Angles = ThrowAngle / 2;
            ps.ThrowRotationSpeed = ThrowRotationSpeed;
        }
        GameState = State.START;
        Timer = StarTime;
    }

    private void OnDisable()
    {
        _music.stop(STOP_MODE.IMMEDIATE);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BoomerangPlayer p in PlayerScript)
        {
            Debug.DrawRay(p.transform.position, p.transform.right * 1000, Color.red);
        } 
        switch (GameState)
        {
            case State.START:
                //Game Start
                Debug.Log("Game has started");
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    GameState = State.AIM;
                    foreach (BoomerangPlayer p in PlayerScript)
                        p.ThrowPhase = true;
                    Timer = GameTime;
                }
                break;
            case State.AIM:
                Debug.Log("AIM Time");
                Timer -= Time.deltaTime;
                if (Timer <= 0 || resetCounter >= 2f)
                {
                    GameState = State.RETURN;
                    foreach (BoomerangPlayer p in PlayerScript)
                    {
                        p.ThrowPhase = false;
                        p.DeactivateUI();
                    }
                    Timer = 3f;
                }
                break;
            case State.RETURN:
                Debug.Log("Returning Time");
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    GameState = State.END;
                }
                break;
            case State.END:
                //Game End
                SceneManager.LoadScene("Score");
                Debug.Log("Game is Over");
                break;
            default:
                Debug.LogWarning("Unknown State Found");
                break;
        }
    }
}
