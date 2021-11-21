using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FMOD.Studio;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoatController : MonoBehaviour
{
    private List<PlayerInputController> _playersControllers;
    [SerializeField] private Transform boatTransform;
    [SerializeField] private Transform croco1;
    [SerializeField] private Transform croco2;
    [SerializeField] private float speed;

    [SerializeField]
    private Animator _player1Animator;
    [SerializeField]
    private Animator _player2Animator;

    [SerializeField] 
    private Animator _croco1Animator;
    [SerializeField] 
    private Animator _croco2Animator;

    [SerializeField] 
    private CanvasGroup _warning1;
    [SerializeField] 
    private CanvasGroup _warning2;
    
    private float player1IdleTimer;
    private float player2IdleTimer;
    private bool isPlayer1Idle;
    private bool isPlayer2Idle;
    private bool isPlayer1Dead;
    private bool isPlayer2Dead;
    private float _player1LastActionTime;
    private float _player2LastActionTime;
    
    private float croco1ChanceRatio;
    private float croco2ChanceRatio;
    private float croco1IdleTimer;
    private float croco2IdleTimer;
    
    private bool isCroco1Attacking;
    private bool isCroco2Attacking;
    private float croco1AttackTimer;
    private float croco2AttackTimer;
    
    private Vector2 _startPosition;
    private Vector2 _currentPosition;

    [SerializeField]
    private TextMeshProUGUI _timerTextMesh;
    private float _timer;

    [FormerlySerializedAs("_timeUp")] [SerializeField] 
    private TextMeshProUGUI _timeUpText;
    
    [SerializeField] 
    private TextMeshProUGUI gameOverText;

    private bool isGameOver;

    private Score _scoreScript;

    private FMOD.Studio.EventInstance rugido;
    private FMOD.Studio.EventInstance splash;

    private void Start()
    {
        _startPosition = boatTransform.position;
        _currentPosition = _startPosition;
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();
        _player1LastActionTime = 0;
        _player2LastActionTime = 0;
        croco1AttackTimer = 0;
        croco2AttackTimer = 0;
        croco1ChanceRatio = 0;
        croco2ChanceRatio = 0;
        isCroco1Attacking = false;
        isCroco2Attacking = false;
        isPlayer1Idle = true;
        isPlayer2Idle = true;
        isPlayer1Dead = false;
        isPlayer2Dead = false;
        _warning1.alpha = 0;
        _warning2.alpha = 0;
        isGameOver = false;
        _timer = 30;
        _timeUpText.enabled = false;
        gameOverText.enabled = false;
        StartCoroutine(SetChances());
        _scoreScript = FindObjectOfType<Score>();

        rugido = FMODUnity.RuntimeManager.CreateInstance("event:/Jogo do barco/Rugido");
        splash = FMODUnity.RuntimeManager.CreateInstance("event:/Jogo do barco/Splash mãos");
    }

    void Update()
    {
        
        if (!isGameOver)
        {
            _timer -= Time.deltaTime;
            _timerTextMesh.text = Mathf.Round(_timer).ToString();
            if (_timer <= 0)
            {
                isGameOver = true;
                return;
            }
            foreach (var playerController in _playersControllers)
            {
                if (playerController.input.action > 0 && playerController.PlayerIndex == 0)
                {
                    isPlayer1Idle = false;
                    //Debug.Log("pressed 1");
                    _currentPosition.x -= speed * Time.deltaTime;
                    _player1LastActionTime = Time.time;
                    _player1Animator.SetTrigger("Action");
                    splash.start();
                }
                else if (playerController.input.action == 0 && playerController.PlayerIndex == 0)
                {
                    //Debug.Log("Player 1 no Input");
                    if ((Time.time - _player1LastActionTime) > 1.25f)
                    {
                        croco1AttackTimer = 0;
                        isPlayer1Idle = true;
                        isCroco1Attacking = false;
                    }
                }
                

                if (playerController.input.action > 0 && playerController.PlayerIndex == 1)
                {
                    isPlayer2Idle = false;
                    //Debug.Log("pressed 2");
                    _currentPosition.x += speed * Time.deltaTime;
                    _player2LastActionTime = Time.time;
                    _player2Animator.SetTrigger("Action");
                }
                else if (playerController.input.action == 0 && playerController.PlayerIndex == 1)
                {
                    //Debug.Log("Player 2 no Input");
                    if ((Time.time - _player2LastActionTime) > 1.25f)
                    {
                        croco2AttackTimer = 0;
                        isPlayer2Idle = true;
                        isCroco2Attacking = false;
                    }
                }
                
            }
            
            //_player1Animator.SetBool("Action", !isPlayer1Idle);
            //_player2Animator.SetBool("Action", !isPlayer2Idle);
            //Debug.Log("Player1: " + _playersControllers[0].input.action);
            //Debug.Log("Player2: " + _playersControllers[1].input.action);

            boatTransform.position = _currentPosition;

            if (isCroco1Attacking)
            {
                if (_warning1.alpha == 0)
                {
                    _warning1.alpha = 1;
                }
                croco1AttackTimer += Time.deltaTime;
                if (croco1ChanceRatio == 0.3f)
                {
                    if (croco1AttackTimer > 2.5f)
                    {
                        isPlayer1Dead = true; ;
                        isGameOver = true;
                    }
                }

                if (croco1ChanceRatio == 0.2f)
                {
                    if (croco1AttackTimer > 3f)
                    {
                        isPlayer1Dead = true;
                        isGameOver = true;
                    }
                }

                if (croco1ChanceRatio == 0.1f)
                {
                    if (croco1AttackTimer > 3.5f)
                    {
                        isPlayer1Dead = true;
                        isGameOver = true;
                    }
                }

            }
            else
            {
                if (_warning1.alpha == 1)
                {
                    _warning1.alpha = 0;  
                }
            }

            if (isCroco2Attacking)
            {
                if (_warning2.alpha == 0)
                {
                    _warning2.alpha = 1;
                }
                croco2AttackTimer += Time.deltaTime;
                if (croco2ChanceRatio == 0.3f)
                {
                    if (croco2AttackTimer > 2.5f)
                    {
                        isPlayer2Dead = true;
                        isGameOver = true;
                    }
                }

                if (croco2ChanceRatio == 0.2f)
                {
                    if (croco2AttackTimer > 3f)
                    {
                        isPlayer2Dead = true;
                        isGameOver = true;
                    }
                }

                if (croco2ChanceRatio == 0.1f)
                {
                    if (croco2AttackTimer > 3.5f)
                    {
                        isPlayer2Dead = true;
                        isGameOver = true;
                    }
                }
            }
            else
            {
                if (_warning2.alpha == 1)
                {
                    _warning2.alpha = 0;
                }
            }
            
            Debug.Log("isPlayer1Idle: " + isPlayer1Idle);
            Debug.Log("isPlayer2Idle: " + isPlayer2Idle);
            _croco1Animator.SetBool("Wait", isCroco1Attacking);
            _croco2Animator.SetBool("Wait", isCroco2Attacking);

            if (_currentPosition.x >= 5.30f)
            {
                isGameOver = true;
            }

            if (_currentPosition.x <= -5.30f)
            {
                isGameOver = true;
            }
            
        }
        else
        {
            if (isPlayer1Dead || isPlayer2Dead)
            {
                splash.stop(STOP_MODE.IMMEDIATE);
                rugido.start();
            }
            StartCoroutine(DeathAnimation());
            Debug.Log("Gameover");
        }

    }

    IEnumerator DeathAnimation()
    {
        
        if (isPlayer1Dead)
        {
            yield return new WaitForSeconds(1f);
            _warning1.alpha = 0;
            _croco1Animator.SetBool("Attack", true);
            croco1.localPosition = new Vector3(croco1.localPosition.x, 1f, croco1.localPosition.z);
            yield return new WaitForSeconds(2f);
            _player1Animator.SetBool("Die", true);
            croco1.localPosition = new Vector3(croco1.localPosition.x, -1f, croco1.localPosition.z);
        }

        if (isPlayer2Dead)
        {
            yield return new WaitForSeconds(1f);
            _warning2.alpha = 0;
            _croco2Animator.SetBool("Attack", true);
            croco2.localPosition = new Vector3(croco2.localPosition.x, 1f, croco2.localPosition.z);
            yield return new WaitForSeconds(2f);
            _player2Animator.SetBool("Die", true);
            croco2.localPosition = new Vector3(croco2.localPosition.x, -1f, croco2.localPosition.z);
        }

        if (_timer <= 0)
        {
            _timerTextMesh.enabled = true;
        }
        else
        {
            gameOverText.enabled = true;
        }

        if (boatTransform.position.x < 0)
        {
            Debug.Log(_scoreScript);
            _scoreScript.player1Score++;
        }

        if (boatTransform.position.x > 0)
        {
            _scoreScript.player2Score++;
        }
        SceneManager.LoadScene("Score");
        yield return null;
    }
    

    IEnumerator SetChances()
    {
        while (!isGameOver)
        {
            if (_currentPosition.x > 0f)
            {
                croco2ChanceRatio = 0f;
            }
            if (_currentPosition.x > 1f)
            {
                croco2ChanceRatio = 0.1f;
            }
            if (_currentPosition.x > 1.25f)
            {
                croco2ChanceRatio = 0.2f;
            }
            if (_currentPosition.x > 2f)
            {
                croco2ChanceRatio = 0.3f;
            }
            
            if (_currentPosition.x < 0f)
            {
                croco1ChanceRatio = 0;
            }
            if (_currentPosition.x < -1f)
            {
                croco1ChanceRatio = 0.1f;
            }
            if (_currentPosition.x < -1.25f)
            {
                croco1ChanceRatio = 0.2f;
            }
            if (_currentPosition.x < -2f)
            {
                croco1ChanceRatio = 0.3f;
            }

            if (Random.Range(0f, 1f) < croco1ChanceRatio && !isCroco1Attacking && !isPlayer1Idle)
            {
                isCroco1Attacking = true;
            }

            if (Random.Range(0f, 1f) < croco2ChanceRatio && !isCroco2Attacking && !isPlayer2Idle)
            {
                isCroco2Attacking = true;
            }

            yield return new WaitForSeconds(1.5f);
            Debug.Log("Chance Set");
            yield return null;
        }

        yield return null;
    }
}

    
