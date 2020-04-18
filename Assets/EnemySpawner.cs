using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    GameObject enemyInstance;

    public GameObject playerPrefab;
    GameObject playerInstance;

    private int scorePlayer;

    float spawnDistance = 12f;

    float enemyRate = 5;
    float nextEnemy = 1;

    void Start()
    {
        scorePlayer = 0;
    }


    void UpdateScore()
    {
        scorePlayer++;
    }


    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;
        
        if (nextEnemy <= 0 && playerPrefab.GetComponent<PlayerSpawner>().playerInstance != null)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;
            if (enemyRate < 2)
                enemyRate = 2;

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            UpdateScore();

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }

    void OnGUI()
    {
        if (scorePlayer >= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 38, 0, 100, 50), "Score: " + scorePlayer);
        }
    }



}