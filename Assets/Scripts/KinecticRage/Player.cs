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
    public bool keyPressed;

    private List<PlayerInputController> _playersControllers;
    public PlayerInput playerInput;
    public float horizontalMovement;
    
    void Start()
    {
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();
        foreach (var player in _playersControllers)
        {
            Debug.Log(player.PlayerIndex);
        }
        keyPressed = false;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        playerInput = gameObject.GetComponent<PlayerInput>();
        
    }

    void Update()
    {
        if (levelManager.gameHasStarted)
        {
            foreach (var playerController in _playersControllers)
            {
                if (playerController.input.horizontalMovement == 0)
                {
                    Debug.Log(playerController.input.horizontalMovement);
                    keyPressed = true;
                    //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, leftPos.transform.position, Time.deltaTime * 5);
                }
                else if (playerController.input.horizontalMovement == 1)
                {
                    Debug.Log(playerController.input.horizontalMovement);
                    keyPressed = true;
                    //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, leftPos.transform.position, Time.deltaTime * 5);
                }
            }
            
            //if (keyPressed = false)
            //{
            //    gameObject.transform.position = centerPos.transform.position;
            //}
            //if ()
            //{
            //    keyPressed = true;
            //    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, leftPos.transform.position, Time.deltaTime * 5);
            //}
            //else
            //{
            //    keyPressed = false;
            //}
            //if (Input.GetButtonDown("d"))
            //{
            //    keyPressed = true;

            //}
            //else
            //{
            //    keyPressed = false;
            //    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, rightPos.transform.position, Time.deltaTime * 5);
            //}
        }


    }

    
}
