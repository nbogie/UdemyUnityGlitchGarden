using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform gunTransform;

    private Transform projectileParent;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject par = GameObject.Find("Projectiles");
        if (par == null)
        {
            Debug.LogError("No object named 'Projectiles' found in scene!");
        }
        projectileParent = par.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FireProjectileIfPossible();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            HackStartAttack();
        }
    }


    void HackStartAttack()
    {
        if (animator)
        {

            animator.SetBool("isAttacking", !animator.GetBool("isAttacking"));
        }
    }


    public void FireProjectileIfPossible()
    {        
        if (projectilePrefab)
        {
            Instantiate(projectilePrefab, gunTransform.position, Quaternion.identity, projectileParent);
        }
    }

}
