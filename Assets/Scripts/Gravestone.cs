using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AttackerScript>())
        {
            animator.SetTrigger("underAttackTrigger");
        }
    }
}