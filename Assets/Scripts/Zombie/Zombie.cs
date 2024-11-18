using System;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

enum ZombieState
{
    Move,
    Eat,
    Die
}
public class Zombie : MonoBehaviour
{
    ZombieState zombieState = ZombieState.Move;
    private Rigidbody2D rb;
    public float moveSpeed;
    private Animator anim;

    public int atkValue = 20;
    public float atkDuration = 2;
    private float atkTimer = 0;

    private Plant currentEatPlant;
    public int HP = 100;
    [SerializeField]
    private int currentHP;

    public GameObject ZombieHeadPrefab;
    private bool haveHead = true;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHP = HP;
    }
    void Update()
    {
        switch (zombieState)
        {
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Eat:
                EatUpdate();
                break;
            case ZombieState.Die:
                break;
            default:
                break;
        }

    }
    void MoveUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * Time.deltaTime * moveSpeed);
    }
    void EatUpdate()
    {
        atkTimer += Time.deltaTime;
        if (atkTimer > atkDuration && currentEatPlant != null)
        {
            currentEatPlant.TakeDamage(atkValue);
            atkTimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", true);
            TranstionToEat();
            currentEatPlant = collision.GetComponent<Plant>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", false);
            zombieState = ZombieState.Move;
            currentEatPlant = null;
        }
    }
    void TranstionToEat()
    {
        zombieState = ZombieState.Eat;
        atkTimer = 0;
    }
    public void TakeDamage(int damage)
    {
        if (currentHP <= 0) return;
        this.currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = -1;
            Dead();
        }

        float hpPercent = currentHP * 1f / HP;
        anim.SetFloat("HPPercent", hpPercent);
        if (hpPercent < .3f && haveHead == true)
        {
            haveHead = false;
            GameObject go = GameObject.Instantiate(ZombieHeadPrefab, transform.position, Quaternion.identity);
            Destroy(go, 2);
        }
    }

    private void Dead()
    {
        zombieState = ZombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject, 2);
    }
}
