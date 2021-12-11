using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public int hp;

    public void TakingDamage(int bulletAttack)
    {
        hp -= bulletAttack;

        if (hp <= 0)
        {
            gameObject.SetActive(false);
            
            if (gameObject.GetComponent<Enemy>())
            {
                if (GetComponent<Enemy>().restoration < 4)
                {
                    gameObject.GetComponent<Enemy>().EnemySpawning();
                    hp = 5;;
                }
                else
                {
                    Destroy(gameObject);
                }
                
            }

            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
