using UnityEngine;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
public class Defender : MonoBehaviour
{
    private Health health;
    private Animator animator;
    private AttackerSpawner attackerSpawner;
    private StarCounter starCounter;

    [Tooltip("Cost to spawn")]
    public int spawnCost;

    void Start()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();

        attackerSpawner = FindObjectOfType<AttackerSpawner>();
        starCounter = FindObjectOfType<StarCounter>();

        if (!attackerSpawner)
        {
            Debug.LogError("Can't find attacker spawner!");
        }
        if (!starCounter)
        {
            Debug.LogError("Can't find star counter!");
        }

    }

    void AddStars(){
        starCounter.AddStars();
    }

	void Update()
	{
        //TODO: unnecessary to do this check EVERY frame!
        //TODO: not all defenders have this parameter in animator
        animator.SetBool("isAttacking", attackerSpawner.AreThereEnemiesEastOfLane(transform.position));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }
    public void TakeDamage(int dmg)
    {
        health.TakeDamage(dmg);
    }


}
