using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{    
    private PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        AttackerScript attacker = obj.GetComponent<AttackerScript>();
        if (attacker)
        {
            int dmg = attacker.GetDamageOnTouchdown();
            playerHealth.TakeDamage(dmg);
            Destroy(obj);
        }
    }
}
