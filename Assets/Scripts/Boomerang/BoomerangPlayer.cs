using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoomerangPlayer : MonoBehaviour
{
    public bool ThrowPhase = false;
    bool Thrown = false;

    //Game Variables
    public float Angles;
    float myAngle;
    bool direction = true;
    public float ThrowRotationSpeed;

    public GameObject Boomerang;
    
    private List<PlayerInputController> _playersControllers;
    

    void Start()
    {
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();

        if (Random.value > 0.5f)
        {
            myAngle = Random.Range(0, Angles);
            direction = false;
        }
        else
        {
            myAngle = Random.Range(0, -Angles);
            direction = true;
        }
    }

    void Update()
    {
        if (!Thrown && ThrowPhase)
        {
            if (direction)
            {
                myAngle += Time.deltaTime * ThrowRotationSpeed;
            }
            else
            {
                myAngle -= Time.deltaTime * ThrowRotationSpeed;
            }
            if (myAngle >= Angles) direction = false;
            if (myAngle <= -Angles) direction = true;
            Mathf.Clamp(myAngle, -Angles, Angles);
            transform.rotation = Quaternion.Euler(0, 0, myAngle);
        }

        foreach (var playerController in _playersControllers)
        {
            if (playerController.input.action > 0)
            {
                ThrowBoomerang();
            }
        }
    }

    //public void ThrowBoomerangEvent(InputAction.CallbackContext ctx) => ThrowBoomerang();

    public void ThrowBoomerang()
    {
        if (!Thrown && ThrowPhase)
        {
            Thrown = true;
            Debug.Log("Throw Registered");
            GameObject go = Instantiate(Boomerang,transform.parent.parent);
            go.GetComponent<BoomerangLogic>().Direction = transform.right;
            //GameObject go = Instantiate();
        }
    }
    
}
