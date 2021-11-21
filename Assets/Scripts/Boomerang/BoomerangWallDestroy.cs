using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoomerangWallDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Boomerang"))
        {
            if (col.transform.childCount > 0)
                foreach (PlayerInputController x in FindObjectsOfType<PlayerInputController>().ToList())
                    if (x.PlayerIndex == col.GetComponent<BoomerangLogic>().PlayerThrowID)
                        x.Score += 1;
            GameObject.Destroy(col.gameObject);
        }
    }
}
