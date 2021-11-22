using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoomerangWallDestroy : MonoBehaviour
{
    private Score _scoreScript;
    private BoomerangGameplay _boomerangGameplay;

    private void Start()
    {
        _boomerangGameplay = FindObjectOfType<BoomerangGameplay>();
        _scoreScript = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Boomerang"))
        {

            _boomerangGameplay.resetCounter++;
            if (col.transform.childCount > 0)
                foreach (PlayerInputController x in FindObjectsOfType<PlayerInputController>().ToList())
                    if (x.PlayerIndex == col.GetComponent<BoomerangLogic>().PlayerThrowID)
                        if (col.GetComponent<BoomerangLogic>().PlayerThrowID == 0)
                        {
                            _scoreScript.player1Score++;
                        }
                        else
                        {
                            _scoreScript.player2Score++;
                        }
            GameObject.Destroy(col.gameObject);
        }
    }
}
