using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        damageDealer.Hit();
        enemyHealth -= damageDealer.GetDamageAmount();

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
