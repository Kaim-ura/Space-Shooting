using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    public float bulletSpeed = 10f;

    public int bulletAttack = 1;

    public int restoration = 0;

    [SerializeField] GameObject enemyBullet;

    [SerializeField] GameObject aim;

    [SerializeField] GameObject location1;

    [SerializeField] GameObject location2;

    [SerializeField] Transform loc1, loc2;

    [SerializeField] GameObject player;

    Vector3 locationTarget;

    private void Start()
    {
        location1.GetComponent<LocationSpawn>().Spawning();

        locationTarget = loc1.position;

        InvokeRepeating(nameof(EnemyShooting), 0f, 1f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, locationTarget, Time.deltaTime * speed);

        if (Mathf.Abs(gameObject.transform.position.x - locationTarget.x) < 0.0001f)
        {
            if (locationTarget == loc1.position)
            {
                locationTarget = loc2.position;
                location1.GetComponent<LocationSpawn>().Spawning();
            }
            else
            {
                locationTarget = loc1.position;
                location2.GetComponent<LocationSpawn>().Spawning();
            }
        }

        if (gameObject.transform.position.x < locationTarget.x)
        {
            gameObject.transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void EnemyShooting()
    {
            GameObject EnemyBullet = Instantiate(enemyBullet, transform.position, Quaternion.Euler(0f, 0f, 90f));

            EnemyBullet.GetComponent<Bullet>().Initialized(aim.transform.position - transform.position, bulletSpeed, bulletAttack);

            EnemyBullet.GetComponent<Bullet>().Shoot(aim.transform.position - transform.position, bulletSpeed, bulletAttack);    
    }

    public void EnemySpawning()
    {
        gameObject.SetActive(true);

        float randomX, randomY;

        randomX = Random.Range(-9.5f, 9.5f);
        randomY = Random.Range(-4.45f, 4.45f);

        transform.position = new Vector3(randomX, randomY, 0f);

        restoration++;

    }
}