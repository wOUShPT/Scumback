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

    public bool canMove;

    public Enemy enemy;

    public SpriteRenderer spriteR;

    public int pos;

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

        canMove = true;
    }

    void Update()
    {
        if (levelManager.gameHasStarted && enemy.attackHit == false)
        {
            foreach (var playerController in _playersControllers)
            {
                if (playerController.PlayerIndex == 0)
                {
                    if (playerController.input.horizontalMovement == -1 && canMove == true)
                    {
                        if (gameObject.transform.position.x >= -3)
                        {
                            spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/R_dodge");
                            gameObject.transform.position = leftPos.transform.position;
                            pos = 0;
                        }

                    }
                    else if (playerController.input.horizontalMovement == 1 && canMove == true)
                    {
                        spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/dodge");
                        gameObject.transform.position = rightPos.transform.position;
                        pos = 2;
                    }
                    else if (playerController.input.horizontalMovement == 0 && canMove == true)
                    {
                        spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/idle");
                        gameObject.transform.position = originalPos;
                        pos = 1;
                    }
                }
            }
        }
    } 
}
