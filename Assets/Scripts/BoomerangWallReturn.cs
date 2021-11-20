using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangWallReturn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Boomerang"))
        {
            BoomerangLogic Logic = col.gameObject.GetComponent<BoomerangLogic>();
            Logic.BoomerangTimer = 0;
            Logic.HitAWall = true;
        }
    }
}
