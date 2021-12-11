using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float bulletSpeed = 20f;

    public int bulletAttack = 1;


    [SerializeField] GameObject playerBullet;

    [SerializeField] GameObject aim;

    private void Start()
    {
        gameObject.SetActive(true);

        GetComponent<Transform>().position = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerShoot();
        } 
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerShoot()
    {
        GameObject PlayerBullet = Instantiate(playerBullet, transform.position, Quaternion.Euler(0f, 0f, 90f));

        playerBullet.GetComponent<Bullet>().Initialized(aim.transform.position - transform.position, bulletSpeed, bulletAttack);

        PlayerBullet.GetComponent<Bullet>().Shoot(aim.transform.position - transform.position, bulletSpeed, bulletAttack);
    }

    private void PlayerMove()
    {
        Rigidbody2D rigidbody2D;

        float directionX, directionY;
        float moveSpeed = 5f;

        rigidbody2D = GetComponent<Rigidbody2D>();

        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");

        if (directionX < 0)
        {
            GetComponent<Transform>().localScale = new Vector3(-0.5f, gameObject.transform.localScale.y, 0f);
            aim.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x - 1f, transform.position.y, transform.position.z);
        }
        else if (directionX > 0)
        {
            GetComponent<Transform>().localScale = new Vector3(0.5f, gameObject.transform.localScale.y, 0f);
            aim.GetComponent<Transform>().position = new Vector3(gameObject.transform.position.x + 1f, transform.position.y, transform.position.z);
        }

        rigidbody2D.velocity = moveSpeed * new Vector3(directionX, directionY, 0f).normalized;
    }
}
