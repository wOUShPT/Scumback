using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
        lastPlayer1Score = 0;
        lastPlayer2Score = 0;
        player1Score = 0;
        player2Score = 0;
    }

    public int lastPlayer1Score;
    public int lastPlayer2Score;
    public int player1Score;
    public int player2Score;
}
