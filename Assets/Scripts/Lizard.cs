using UnityEngine;

[RequireComponent(typeof(AttackerScript))]
public class Lizard : MonoBehaviour
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
        if (!collision.gameObject.CompareTag("Defender"))
        {
            return;
        }
        animator.SetBool("isAttacking", true);
        attackerScript.Attack(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
