using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int scene;

    private void Start()
    {
        InvokeRepeating(nameof(LevelCheck), 5f, 1f);
    }
    private void LevelCheck()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(enemies.Length);

        if (enemies.Length == 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
