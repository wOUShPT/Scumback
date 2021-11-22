using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _winnerText;
    private Score _scoreScript;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _scoreScript = FindObjectOfType<Score>();
        if (_scoreScript.player1Score > _scoreScript.player2Score)
        {
            _winnerText.text = "Player 1 Wins";
        }
        else if (_scoreScript.player1Score < _scoreScript.player2Score)
        {
            _winnerText.text = "Player 2 Wins ";
        }
        else
        {
            _winnerText.text = "It's a Draw";
        }
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
    
}
