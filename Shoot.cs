using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ParticleSystem shootPS;
    public Transform firePoint;
    [SerializeField] private int damage = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<PlayerController>().TakeDMG(10);
            CreateShoot();
            Shooting();
        }
    }
    void Shooting()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        }
    }
    void CreateShoot()
    {
        shootPS.Play();
    }
}
