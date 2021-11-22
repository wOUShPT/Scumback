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

    public Player player;

    public LevelManager levelManager;

    public bool isAttacking;
    public bool hasAttacked;
    public bool attackHit;

    public float randomValue;
    public float attackTimer;

    public float swingTime;

    private List<PlayerInputController> _playersControllers;

    public Collider2D rightFistCol;
    public Collider2D leftFistCol;

    public SpriteRenderer spriteR;
    public SpriteRenderer playerSpriteR;

    private FMOD.Studio.EventInstance punch;
    private FMOD.Studio.EventInstance pain;
    
    

    void Start()
    {
        _playersControllers = FindObjectsOfType<PlayerInputController>().ToList();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        rightFistCol.enabled = false;
        leftFistCol.enabled = false;
        isAttacking = false;
        attackHit = false;
        canAttackSprite.SetActive(false);

        punch = FMODUnity.RuntimeManager.CreateInstance("event:/Jogo da porrada/Punch");
        pain = FMODUnity.RuntimeManager.CreateInstance("event:/Jogo da porrada/Dor char A");
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
                        StartCoroutine(AttackLeft());
                    }
                    if (playerController.input.action == 1 && isAttacking == false)
                    {
                        Debug.Log("Right Punch");
                        StartCoroutine(AttackRight());
                    }
                }
            }
        }
    }

    IEnumerator AttackLeft()
    {
        isAttacking = true;
        spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/R_BullyWindup");
        yield return new WaitForSeconds(swingTime);
        //ENEMY IS GOING TO ATTACK TEXT/PROMPT
        Debug.Log("AttackLeft");
        leftFistCol.enabled = true;
        spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/R_BullyPunch");
        //yield return new WaitForSeconds(0.5f);
        if (player.pos == 0)
        {
            player.canMove = false;
            punch.start();
            pain.start();
            playerSpriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/R_Punched");
            yield return new WaitForSeconds(0.5f);
            spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/Bully");
            playerSpriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/idle");
            levelManager.player1Score++;
            levelManager.player2HP += 5;
            leftFistCol.enabled = false;
            attackTimer = 0;
            isAttacking = false;
            player.canMove = true;
            yield return attackHit = false;
        }
        if (attackTimer >= swingTime && attackHit == false)
        {
            yield return new WaitForSeconds(0.5f);
            spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/Bully");
            levelManager.player2HP += 5;
            leftFistCol.enabled = false;
            isAttacking = false;
            yield return attackTimer = 0;
        }
    }

    IEnumerator AttackRight()
    {
        isAttacking = true;
        spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/BullyWindup");
        yield return new WaitForSeconds(swingTime);
        //ENEMY IS GOING TO ATTACK TEXT/PROMPT
        Debug.Log("AttackRight");
        rightFistCol.enabled = true;
        spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/BullyPunch");
        //yield return new WaitForSeconds(0.5f);
        if (player.pos == 2)
        {
            Debug.Log("punched");
            player.canMove = false;
            punch.start();
            pain.start();
            playerSpriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/Punched");
            yield return new WaitForSeconds(0.5f);
            spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/Bully");
            playerSpriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/idle");
            levelManager.player1Score++;
            levelManager.player2HP += 5;
            rightFistCol.enabled = false;
            attackTimer = 0;
            isAttacking = false;
            player.canMove = true;
            yield return attackHit = false;
        }

        if (attackTimer >= swingTime && attackHit == false)
        {
            Debug.Log("skippedpunch");
            yield return new WaitForSeconds(0.5f);
            spriteR.sprite = Resources.Load<Sprite>("Sprites/Fight/Bully");
            rightFistCol.enabled = false;
            isAttacking = false;
            yield return attackTimer = 0;
        }
    }
}
