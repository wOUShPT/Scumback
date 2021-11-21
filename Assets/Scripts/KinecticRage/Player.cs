using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject leftPos;
    public GameObject centerPos;
    public GameObject rightPos;

    public Enemy enemy;

    public Vector3 originalPos;

    private List<PlayerInputController> _playersControllers;
    
    void Start()
    {
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();
        foreach (var player in _playersControllers)
        {
            Debug.Log(player.PlayerIndex);
        }

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        originalPos = gameObject.transform.position;
    }

    void Update()
    {
        if (levelManager.gameHasStarted && enemy.attackHit == false)
        {
            foreach (var playerController in _playersControllers)
            {
                if (playerController.PlayerIndex == 0)
                {
                    if (playerController.input.horizontalMovement == -1)
                    {
                        if (gameObject.transform.position.x >= -3)
                        {
                            gameObject.transform.position = leftPos.transform.position;
                        }

                    }
                    else if (playerController.input.horizontalMovement == 1)
                    {
                        gameObject.transform.position = rightPos.transform.position;
                    }
                    else if (playerController.input.horizontalMovement == 0)
                    {
                        gameObject.transform.position = originalPos;
                    }
                }
            }
        }
    } 
}
