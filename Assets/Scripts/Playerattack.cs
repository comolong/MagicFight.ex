using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public int damage;
    private Animator animator;
    private PolygonCollider2D collider2D;
    public float attackdelay;
    public float attack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Melee");
            StartCoroutine(StartAttack());
        }
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(attackdelay);
        collider2D.enabled = true;
        StartCoroutine(Attacking());
    }
    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(attack);
        collider2D.enabled = false;

    }
}