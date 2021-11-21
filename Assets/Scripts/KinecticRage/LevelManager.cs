using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float startGame;
    public float gameTimer;
    public bool gameHasStarted;
    public int player1Score;
    public float player2HP;

    public float decreaseP2HpValue;

    public Slider enemySlider;
    public TMPro.TMP_Text player1ScoreTxt;
    public TMPro.TMP_Text gameTimerTxt;

    private void Start()
    {
        gameTimer = 30;
        player2HP = 100;
        gameHasStarted = false;

        enemySlider.maxValue = 100;
        enemySlider.minValue = 0;
    }

    private void Update()
    {
        gameTimer -= Time.deltaTime;
        enemySlider.value = player2HP;
        player1ScoreTxt.text = player1Score.ToString();
        gameTimerTxt.text = Mathf.RoundToInt(gameTimer).ToString();

        if (player2HP >= 100)
        {
            player2HP = 100;
        }
        startGame += Time.deltaTime;
        player2HP -= Time.deltaTime * decreaseP2HpValue;

        if (startGame >= 2 && gameHasStarted == false)
        {
            gameHasStarted = true;
        }

        if (player1Score >= 20 || player2HP <= 0)
        {
            gameHasStarted = false;
            Debug.Log("Player1Wins");

            //if time runs out player2wins
        }
        else if (gameTimer <= 0)
        {
            gameHasStarted = false;
            Debug.Log("Player2Wins");
        }    
    }
}
