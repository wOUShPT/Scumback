using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public Enemy enemy;
    public Collider2D thisCol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.attackHit == false)
        {
            if (collision.CompareTag("Player"))
            {
                thisCol.enabled = false;
                enemy.attackHit = true;
            }
        }
    }
}
