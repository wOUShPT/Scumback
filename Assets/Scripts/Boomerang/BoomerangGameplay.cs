using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    enum State
    {
        START,
        AIM,
        RETURN,
        END
    }

    private State GameState;
    
    void Start()
    {
        //PlayerScript = Player.GetComponent<BoomerangPlayer>();

        foreach(BoomerangPlayer ps in PlayerScript)
        {
            ps.Angles = ThrowAngle / 2;
            ps.ThrowRotationSpeed = ThrowRotationSpeed;
        }
        GameState = State.START;
        Timer = StarTime;
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
                if (Timer <= 0)
                {
                    GameState = State.RETURN;
                    foreach (BoomerangPlayer p in PlayerScript)
                        p.ThrowPhase = false;
                    Timer = 5f;
                }
                break;
            case State.RETURN:
                Debug.Log("Returning Time");
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    GameState = State.END;
                    foreach (BoomerangPlayer p in PlayerScript)
                        p.ThrowPhase = false;
                    Timer = 2f;
                }
                break;
            case State.END:
                //Game End
                Debug.Log("Game is Over");
                break;
            default:
                Debug.LogWarning("Unknown State Found");
                break;
        }
    }
}
