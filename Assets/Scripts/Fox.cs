using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackerScript))]
[RequireComponent(typeof(Animator))]
public class Fox : MonoBehaviour
{
    private Animator animator;
    private AttackerScript attackerScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        attackerScript = GetComponent<AttackerScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defender>()){
            return;
        }
        if (obj.GetComponent<Gravestone>())
        {
            animator.SetTrigger("jumpTrigger");
        }
        else
        {
            animator.SetBool("isAttacking", true);
            attackerScript.Attack(obj);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
