using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject leftPos;
    public GameObject centerPos;
    public GameObject rightPos;
    public bool keyPressed;

    public PlayerInput playerInput;
    public float horizontalMovement;
    
    void Start()
    {
        keyPressed = false;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        playerInput = gameObject.GetComponent<PlayerInput>();
        
    }

    void Update()
    {
        if (levelManager.gameHasStarted)
        {
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

    public void SetMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
        Debug.Log(horizontalMovement);
        if (horizontalMovement == 0)
        {
            keyPressed = true;
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, leftPos.transform.position, Time.deltaTime * 5);
        }
        else if (horizontalMovement == 1)
        {
            keyPressed = true;
            //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, leftPos.transform.position, Time.deltaTime * 5);
        }
    }
}
