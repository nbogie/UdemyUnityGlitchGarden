using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttackerScript : MonoBehaviour
{
    public GameObject dmgSignPrefab;

    private float currentSpeed = 0.75f;
    private AudioSource audioSource;
    private Animator animator;
    private GameObject currentTarget;
    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;
    [Tooltip("How much damage this attacker does if it crosses home line.")]
    public int damageOnTouchdown;

    #region Unity Methods

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!currentTarget){
            animator.SetBool("isAttacking", false);
        }
        MoveForwards();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            HackMoveBack();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            HackTeleport();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            HackStartAttack();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            HackStartJump();
        }
    }
    #endregion

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    void MoveForwards()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void Attack(GameObject target)
    {
        if (target.CompareTag("Defender"))
        {
            currentTarget = target;
        }
        else
        {
            Debug.LogError("can't attack non-defender");
        }

    }

    public void StrikeCurrentTarget(int dmg)
    {
        Instantiate(dmgSignPrefab, transform);
        //TODO: target might have died for other reasons
        if (currentTarget)
        {
            Defender defender = currentTarget.GetComponent<Defender>();
            defender.TakeDamage(dmg);
        }
    }

    void MaybeStartAttackAnimSound()
    {
        if (audioSource)
        {
            if (Random.value > 0.8f)
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogError("no audio source for attacker " + gameObject.name);
        }
    }
    public int GetDamageOnTouchdown()
    {
        return damageOnTouchdown;
    }

    #region Hacks for Debugging 

    void HackTeleport()
    {
        transform.position = new Vector2(9, Random.Range(1, 5+1));
    }

    void HackMoveBack()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 3f);
    }

    void HackStartAttack()
    {
        if (animator)
        {
            animator.SetBool("isAttacking", !animator.GetBool("isAttacking"));
        }
    }

    void HackStartJump()
    {
        if (animator)
        {
            animator.SetBool("isAttacking", false);
            animator.SetTrigger("jumpTrigger");
        }
    }
    #endregion

}
