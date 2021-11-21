using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatController : MonoBehaviour
{
    private List<PlayerInputController> _playersControllers;
    [SerializeField] private Transform boatTransform;

    [SerializeField] private float speed;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;

    private void Start()
    {
        _startPosition = boatTransform.position;
        _currentPosition = _startPosition;
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();
        foreach (var player in _playersControllers)
        {
            Debug.Log(player.PlayerIndex);
        }
    }

    void Update()
    {
        foreach (var playerController in _playersControllers)
        {
            if (playerController.input.action > 0 && playerController.PlayerIndex == 0)
            {
                _currentPosition.x -= speed * Time.deltaTime;
            }

            if (playerController.input.action > 0 && playerController.PlayerIndex == 1)
            {
                _currentPosition.x += speed * Time.deltaTime;
            }
        }
        boatTransform.position = _currentPosition;
    }
}

    
