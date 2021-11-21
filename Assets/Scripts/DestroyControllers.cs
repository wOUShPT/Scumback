using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyControllers : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<PlayerInputManager>())
        {
            Destroy(FindObjectOfType<PlayerInputManager>());
        }
    }

}
