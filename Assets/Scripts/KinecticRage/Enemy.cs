using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public GameObject rightFist;
    public GameObject leftFist;
    public GameObject canAttackSprite;

    public LevelManager levelManager;

    public bool isAttacking;
    public bool hasAttacked;
    public bool attackHit;

    public float randomValue;
    public float attackTimer;

    public int swingTime;

    private List<PlayerInputController> _playersControllers;

    public Collider2D rightFistCol;
    public Collider2D leftFistCol;

    void Start()
    {
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        rightFistCol.enabled = false;
        leftFistCol.enabled = false;
        isAttacking = false;
        hasAttacked = false;
        attackHit = false;
        canAttackSprite.SetActive(false);
    }

    void Update()
    {
        if (isAttacking == true)
        {
            attackTimer += Time.deltaTime;
            canAttackSprite.SetActive(false);
        }
        else
        {
            canAttackSprite.SetActive(true);
        }

        if (levelManager.gameHasStarted == true)
        {
            foreach (var playerController in _playersControllers)
            {
                if (playerController.PlayerIndex == 1)
                {
                    if (playerController.input.dodge == 1 && isAttacking == false)
                    {
                        Debug.Log("Left Punch");
                        isAttacking = true;
                        StartCoroutine(AttackLeft());
                    }
                    if (playerController.input.action == 1 && isAttacking == false)
                    {
                        Debug.Log("Right Punch");
                        isAttacking = true;
                        StartCoroutine(AttackRight());
                    }
                }
            }
        }
    }

    IEnumerator AttackLeft()
    {
        yield return new WaitForSeconds(swingTime);
        //ENEMY IS GOING TO ATTACK TEXT/PROMPT
        leftFistCol.enabled = true;

        if (attackHit == true)
        {
            levelManager.player1Score++;
            levelManager.player2HP += 10;
            leftFistCol.enabled = false;
            attackTimer = 0;
            hasAttacked = true;
            isAttacking = false;
            yield return attackHit = false;
        }

        if (attackTimer >= 2 && attackHit == false)
        {
            leftFistCol.enabled = false;
            isAttacking = false;
            yield return attackTimer = 0;
        }
    }

    IEnumerator AttackRight()
    {
        yield return new WaitForSeconds(swingTime);
        //ENEMY IS GOING TO ATTACK TEXT/PROMPT
        rightFistCol.enabled = true;

        if (attackHit == true)
        {
            levelManager.player1Score++;
            levelManager.player2HP += 10;
            rightFistCol.enabled = false;
            attackTimer = 0;
            hasAttacked = true;
            isAttacking = false;
            yield return attackHit = false;
        }

        if (attackTimer >= 2 && attackHit == false)
        {
            rightFistCol.enabled = false;
            isAttacking = false;
            yield return attackTimer = 0;
        }
    }
}
