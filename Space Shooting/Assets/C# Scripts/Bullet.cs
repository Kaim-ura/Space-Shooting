using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public int bulletAttack;

    public Vector2 bulletDirection;

    int hp;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.GetComponent<HP>())
        {
            collision.gameObject.GetComponent<HP>().TakingDamage(bulletAttack);
        }
        Destroy(gameObject);
    }

    public void Initialized(Vector2 bulletDirection, float bulletSpeed, int bulletAttack)
    {
        this.bulletDirection = bulletDirection;
        this.bulletSpeed = bulletSpeed;
        this.bulletAttack = bulletAttack;
    }

    public void Shoot(Vector2 bulletDirection, float bulletSpeed, int bulletAttack)
    {
        Rigidbody2D rigidbody2D;
        rigidbody2D = GetComponent<Rigidbody2D>();

        this.bulletDirection = bulletDirection;
        this.bulletSpeed = bulletSpeed;
        this.bulletAttack = bulletAttack;

        rigidbody2D.velocity = bulletDirection * bulletSpeed;
    }
}
