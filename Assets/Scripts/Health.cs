using UnityEngine;

public class Health : MonoBehaviour
{

    private int hitPoints;

    public int maxHitPoints = 20;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        if (hitPoints < 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
