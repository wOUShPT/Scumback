using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float startGame;
    public float gameTimer;
    public bool gameHasStarted;
    public int player1Score;
    public float player2HP;

    public int condition;

    public float decreaseP2HpValue;
    public SpriteRenderer enemySpriteRenderer;
    public SpriteRenderer playerSpriteRenderer;

    public Slider enemySlider;
    public TMPro.TMP_Text player1ScoreTxt;
    public TMPro.TMP_Text gameTimerTxt;

    private FMOD.Studio.EventInstance puff;
    
    private Score _scoreScript;

    private void Start()
    {
        gameTimer = 30;
        player2HP = 100;
        gameHasStarted = false;

        enemySlider.maxValue = 100;
        enemySlider.minValue = 0;

        condition = 0;
        
        _scoreScript = FindObjectOfType<Score>();
        
        puff = FMODUnity.RuntimeManager.CreateInstance("event:/Jogo da porrada/Puff");
    }

    private void Update()
    {
        if (gameHasStarted == true)
        {
            gameTimer -= Time.deltaTime;
        }
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
            condition = 1;
            Debug.Log("Player1Wins");
            //if time runs out player2wins
            StartCoroutine(Player1Wins());
        }
        else if (gameTimer <= 0)
        {
            condition = 1;
            Debug.Log("Player2Wins");
            StartCoroutine(Player2Wins());
        }

        if (player2HP <= 0)
        {
            condition = 2;
        }

        IEnumerator Player1Wins()
        {
            if (condition == 1)
            {
                yield return new WaitForSeconds(1);
                playerSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Fight/Punching");
                yield return new WaitForSeconds(1);
                enemySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Fight/BullyKO");
            }
            if (condition == 2)
            {
                yield return new WaitForSeconds(1);
                enemySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Fight/skeletal");
                yield return new WaitForSeconds(1);
                puff.start();
                enemySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Fight/Smoke");
            }
            
            gameHasStarted = false;
            _scoreScript.player1Score++;
            SceneManager.LoadScene("Final");
        }
        IEnumerator Player2Wins()
        {
            gameHasStarted = false;
            enemySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Fight/RaiseWin");
            yield return new WaitForSeconds(1);
            playerSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Fight/Defeat");
            yield return new WaitForSeconds(2);
            //logica de ponto PLAYER 2
            _scoreScript.player2Score++;
            SceneManager.LoadScene("Final");
            yield break;
        }
    }
}
