using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public int damage;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;
        AttackerScript attacker = go.GetComponent<AttackerScript>();
        Health attackerHealth = go.GetComponent<Health>();
        if (attacker && attackerHealth)
        {
            attackerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
