using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public Enemy enemy;
    public Collider2D thisCol;

    private void Start()
    {
        thisCol = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            if (collision.CompareTag("Player") == true)
            {
                Debug.Log("ai");
                enemy.attackHit = true;
                thisCol.enabled = false;
            }
    }
}
