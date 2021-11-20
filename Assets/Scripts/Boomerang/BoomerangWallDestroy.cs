using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangWallDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Boomerang"))
        {
            GameObject.Destroy(col.gameObject);
        }
    }
}
