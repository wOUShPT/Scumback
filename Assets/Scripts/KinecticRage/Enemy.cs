using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject rightFist;
    public GameObject leftFist;

    public Vector3 rightFistX;
    public Vector3 rightFistY;

    public Vector3 leftFistX;
    public Vector3 leftFistY;

    public LevelManager levelManager;
    public bool canAttack;
    public bool leftAttack;
    public float randomValue;
    public float attackTimer;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        rightFistX = new Vector3(rightFist.transform.position.x,0,0);
        rightFistY = new Vector3(0, rightFist.transform.position.y, 0);

        leftFistX = new Vector3(leftFist.transform.position.x, 0, 0);
        leftFistY = new Vector3(0, leftFist.transform.position.y, 0);
    }

    void Update()
    {
        if (levelManager.gameHasStarted == true)
        {
            attackTimer += Time.deltaTime;
        }
        if (levelManager.gameHasStarted)
        {
            if (attackTimer >= Random.Range(4, 6))
            {
                canAttack = true;
                attackTimer = 0;
            }

            if (canAttack == true)
            {
                StartCoroutine(DecideFist());
                canAttack = false;
            }
        }
    }

    IEnumerator DecideFist()
    {
        randomValue = Random.value;

        if (randomValue <= 0.5f)
        {
            leftAttack = true;
            yield return StartCoroutine(AttackLeft());
        }
        else if (randomValue > 0.5f)
        {
            leftAttack = false;
            yield return StartCoroutine(AttackRight());
          }
    }

    IEnumerator AttackLeft()
    {
        leftFist.transform.position = Vector3.Lerp(leftFistX, leftFistY + new Vector3(0, 0.4f, 0), Time.deltaTime * 3);
        yield break;
    }

    IEnumerator AttackRight()
    {
        rightFist.transform.position = Vector3.Lerp(rightFistX, rightFistY + new Vector3(0, 0.4f, 0), 5);
        yield break;
    }
    
}
