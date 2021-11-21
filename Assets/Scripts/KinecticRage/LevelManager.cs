using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float gameTimer;
    public bool gameHasStarted;

    private void Start()
    {
        gameHasStarted = false;
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer >= 5 && gameHasStarted == false)
        {
            gameHasStarted = true;
        }
    }
}
