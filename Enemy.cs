using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public ParticleSystem deathPS;

    public void TakeDamage(int damage)
    {
        if(health < 0)
        {
            health = 0;
        }
        health -= damage;
        if(health == 0)
        {
            Death();
        }
    }

    public void Death()
    {
        CreateDeath();
        Destroy(gameObject);
    }
    public void CreateDeath()
    {
        ParticleSystem dps = Instantiate(deathPS);
        dps.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
