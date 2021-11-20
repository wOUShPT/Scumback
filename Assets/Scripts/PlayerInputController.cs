using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _player;
    private int playerIndex;
    public int PlayerIndex => playerIndex;
    public InputStruct input;
    void Awake()
    {
        DontDestroyOnLoad(this);
        _player = GetComponent<PlayerInput>();
        playerIndex = _player.playerIndex;
    }

    public struct InputStruct
    {
        public float action;
        public float dodge;
    }

    public void SetPlayerAction(InputAction.CallbackContext context)
    {
        input.action = context.ReadValue<float>();
    }
    
    public void SetPlayerDodge(InputAction.CallbackContext context)
    {
        input.dodge = context.ReadValue<float>();
    }
    
}
