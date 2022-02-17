using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    public GamesManager _gamesManager;
    public TextMeshProUGUI _player1Score;
    public TextMeshProUGUI _player2Score;
    private Score _scoreScript;

    private void Awake()
    {
        _gamesManager = FindObjectOfType<GamesManager>();
        _scoreScript = FindObjectOfType<Score>();
        _gamesManager.StopAllSnapShots();
        StartCoroutine(UpdateScore());
    }

    IEnumerator UpdateScore()
    {
        _player1Score.text = _scoreScript.lastPlayer1Score.ToString();
        _player2Score.text = _scoreScript.lastPlayer2Score.ToString();
        yield return new WaitForSeconds(2f);
        _scoreScript.lastPlayer1Score = _scoreScript.player1Score;
        _scoreScript.lastPlayer2Score = _scoreScript.player2Score;
        _player1Score.text = _scoreScript.player1Score.ToString();
        _player2Score.text = _scoreScript.player2Score.ToString();
        yield return new WaitForSeconds(3f);
        _gamesManager.currentLevel++;
        SceneManager.LoadScene(_gamesManager.levels[_gamesManager.currentLevel]);
    }

}
